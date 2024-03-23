using Core.Exceptions;
using Core.Models.Accounts;
using Core.Repositories;

namespace Core.Services.AccountServices;

public class AddAccountMoney : ICommandResult<long>
{
    private readonly IAccountRepository _accountRepository;
    private readonly long _amountOfMoney;
    private readonly long _accountId;

    public AddAccountMoney(IAccountRepository accountRepository, long amountOfMoney, long accountId)
    {
        _accountRepository = accountRepository;
        _amountOfMoney = amountOfMoney;
        _accountId = accountId;
    }

    public async Task<long> Execute()
    {
        Account? account = await _accountRepository.GetAccountById(_accountId).ConfigureAwait(false);
        if (account is null)
        {
            throw new EmptyQueryAnswerException(nameof(account));
        }

        await _accountRepository.UpdateAccount(_accountId, account.Balance + _amountOfMoney).ConfigureAwait(false);

        return account.Balance + _amountOfMoney;
    }
}