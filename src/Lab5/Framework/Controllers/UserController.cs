using Core.Exceptions;
using Core.Models.Users;
using Core.Repositories;
using Core.Services;
using Core.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserData userData)
    {
        if (userData is null)
        {
            return BadRequest();
        }

        ICommand command = new CreateUser(_userRepository, userData.Username, userData.Password, userData.UserRole);
        try
        {
            await command.Execute().ConfigureAwait(false);
        }
        catch (SameUsernameException)
        {
            return BadRequest();
        }

        return Ok();
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        ICommandResult<IReadOnlyList<User>> command = new GetAllUsers(_userRepository);
        IReadOnlyList<User>? users = await command.Execute().ConfigureAwait(false);

        return Ok(users);
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost("GetUserByUsername")]
    public async Task<IActionResult> GetUserByUsername([FromBody] string username)
    {
        ICommandResult<User> command = new GetUserByUsername(_userRepository, username);
        User? user;
        try
        {
            user = await command.Execute().ConfigureAwait(false);
        }
        catch (EmptyQueryAnswerException)
        {
            return BadRequest();
        }

        return Ok(user);
    }
}