using System.Security.Claims;
using Core.Exceptions;
using Core.Models.Accounts;
using Core.Repositories;
using Core.Services;
using Core.Services.AccountServices;
using Core.Services.TransactionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AccountController(ILogger<UserController> logger, IUserRepository userRepository, IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor, ITransactionRepository transactionRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _httpContextAccessor = httpContextAccessor;
        _transactionRepository = transactionRepository;
    }

    [Authorize]
    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Forbid();
        }

        Claim? usernameClaim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name);
        if (usernameClaim is null)
        {
            return Forbid();
        }

        ICommand command = new CreateAccount(_accountRepository, usernameClaim.Value, _userRepository);
        try
        {
            await command.Execute().ConfigureAwait(false);
        }
        catch (EmptyQueryAnswerException)
        {
            return BadRequest();
        }

        return Ok();
    }

    [Authorize(Policy = "AllowUser")]
    [HttpGet("GetAccountById")]
    public async Task<IActionResult> GetAccountById(long id)
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Forbid();
        }

        Claim? usernameClaim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name);
        if (usernameClaim is null)
        {
            return Forbid();
        }

        ICommandResult<Account> command = new GetAccountById(_accountRepository, id);
        Account? account = await command.Execute().ConfigureAwait(false);

        return Ok(account);
    }

    [Authorize(Policy = "AllowUser")]
    [HttpPut("AddAccountMoney")]
    public async Task<IActionResult> AddAccountMoney([FromBody] long amountOfMoney, long id)
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Forbid();
        }

        Claim? usernameClaim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name);
        if (usernameClaim is null)
        {
            return Forbid();
        }

        ICommand command = new AddTransaction(_accountRepository, id, new AddAccountMoney(_accountRepository, amountOfMoney, id), _transactionRepository);
        try
        {
            await command.Execute().ConfigureAwait(false);
        }
        catch (EmptyQueryAnswerException)
        {
            return BadRequest();
        }

        return Ok();
    }

    [Authorize(Policy = "AllowUser")]
    [HttpPut("WithdrawAccountMoney")]
    public async Task<IActionResult> WithdrawAccountMoney([FromBody] long amountOfMoney, long id)
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Forbid();
        }

        Claim? usernameClaim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name);
        if (usernameClaim is null)
        {
            return Forbid();
        }

        ICommand command = new AddTransaction(_accountRepository, id, new WithdrawAccountMoney(_accountRepository, amountOfMoney, id), _transactionRepository);
        try
        {
            await command.Execute().ConfigureAwait(false);
        }
        catch (EmptyQueryAnswerException)
        {
            return BadRequest();
        }
        catch (NegativeBalanceException nbe)
        {
            return BadRequest(nbe.ToString());
        }

        return Ok();
    }

    [Authorize(Policy = "AllowUser")]
    [HttpGet("GetAccountBalance")]
    public async Task<IActionResult> GetAccountBalance(long id)
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Forbid();
        }

        Claim? usernameClaim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name);
        if (usernameClaim is null)
        {
            return Forbid();
        }

        ICommandResult<long> command = new GetAccountBalance(_accountRepository, id);
        long balance;
        try
        {
            balance = await command.Execute().ConfigureAwait(false);
        }
        catch (EmptyQueryAnswerException)
        {
            return BadRequest();
        }

        return Ok(balance);
    }

    [Authorize]
    [HttpGet("GetAllAccountsByUser")]
    public async Task<IActionResult> GetAllAccountsByUser()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return Forbid();
        }

        Claim? usernameClaim = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Name);
        if (usernameClaim is null)
        {
            return Forbid();
        }

        ICommandResult<IReadOnlyList<Account>> command = new GetAllAccountsByUsername(_accountRepository, usernameClaim.Value);
        IReadOnlyList<Account>? accounts = await command.Execute().ConfigureAwait(false);

        return Ok(accounts);
    }
}