using System.Globalization;
using System.Security.Claims;
using Core.Exceptions;
using Core.Repositories;
using Core.Services;
using Core.Services.AccountServices;
using Framework.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace Framework.Handlers;

public class UserAuthorizationHandler : AuthorizationHandler<AccountIdAccess>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;

    public UserAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IAccountRepository accountRepository, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _accountRepository = accountRepository;
        _userRepository = userRepository;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AccountIdAccess requirement)
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            throw new ContextNullException(nameof(_httpContextAccessor.HttpContext));
        }

        if (context is null)
        {
            throw new ContextNullException(nameof(context));
        }

        string accountIdString = _httpContextAccessor.HttpContext.Request.Query["id"].ToString();
        long accountId = Convert.ToInt64(accountIdString, new NumberFormatInfo());

        Claim? usernameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.Name);

        if (usernameClaim is null)
        {
            _httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            return;
        }

        try
        {
            ICommand command =
                new AccountTransactionRestriction(_accountRepository, _userRepository, usernameClaim.Value, accountId);
            await command.Execute().ConfigureAwait(false);
            context.Succeed(requirement);
        }
        catch (AuthorizationException)
        {
            context.Fail();
        }
        catch (EmptyQueryAnswerException)
        {
            context.Fail();
        }
    }
}