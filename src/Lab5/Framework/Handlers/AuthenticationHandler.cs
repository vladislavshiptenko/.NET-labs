using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Core.Exceptions;
using Core.Models.Users;
using Core.Repositories;
using Core.Services;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Framework.Handlers;

public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserRepository _userRepository;

    public AuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserRepository userRepository)
        : base(options, logger, encoder, clock)
    {
        _userRepository = userRepository;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization header");
        }

        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

        if (authHeader.Scheme != "Basic")
        {
            return AuthenticateResult.Fail("Invalid Authorization scheme");
        }

        if (authHeader.Parameter is null)
        {
            return AuthenticateResult.Fail("Invalid parameters");
        }

        byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
        string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
        string username = credentials[0];
        string password = credentials[1];

        try
        {
            ICommand command = new UserLogin(username, password, _userRepository);
            await command.Execute().ConfigureAwait(false);
        }
        catch (LoginException le)
        {
            return AuthenticateResult.Fail(le.ToString());
        }

        UserData? userData = await _userRepository.GetUserDataByUsername(username).ConfigureAwait(false);

        if (userData is null)
        {
            return AuthenticateResult.Fail("Unknown error");
        }

        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Name, userData.Username),
            new Claim(ClaimTypes.Role, userData.UserRole),
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}