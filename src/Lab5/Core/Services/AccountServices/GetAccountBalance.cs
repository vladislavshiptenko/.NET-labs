using Core.Exceptions;
using Core.Models.Accounts;
using Core.Repositories;

namespace Core.Services.AccountServices;

public class GetAccountBalance : ICommandResult<long>
{
    private readonly IAccountRepository _accountRepository;
    private readonly long _accountId;

    public GetAccountBalance(IAccountRepository accountRepository, long accountId)
    {
        _accountRepository = accountRepository;
        _accountId = accountId;
    }

    public async Task<long> Execute()
    {
        Account? account = await _accountRepository.GetAccountById(_accountId).ConfigureAwait(false);
        if (account is null)
        {
            throw new EmptyQueryAnswerException(nameof(account));
        }

        return account.Balance;
    }
}