using Core.Exceptions;
using Core.Models.Accounts;
using Core.Models.Users;
using Core.Repositories;

namespace Core.Services.AccountServices;

public class AccountTransactionRestriction : ICommand
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly string _username;
    private readonly long _accountId;

    public AccountTransactionRestriction(IAccountRepository accountRepository, IUserRepository userRepository, string username, long accountId)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _username = username;
        _accountId = accountId;
    }

    public async Task Execute()
    {
        User? user = await _userRepository.GetUserByUsername(_username).ConfigureAwait(false);
        UserData? userData = await _userRepository.GetUserDataByUsername(_username).ConfigureAwait(false);
        Account? account = await _accountRepository.GetAccountById(_accountId).ConfigureAwait(false);

        if (user is null)
        {
            throw new EmptyQueryAnswerException(nameof(user));
        }

        if (account is null)
        {
            throw new EmptyQueryAnswerException(nameof(user));
        }

        if (userData is null)
        {
            throw new EmptyQueryAnswerException(nameof(userData));
        }

        if (user.Id != account.UserId && userData.UserRole != UserRole.Admin)
        {
            throw new AuthorizationException();
        }
    }
}