using Core.Exceptions;
using Core.Models.Accounts;
using Core.Repositories;

namespace Core.Services.TransactionServices;

public class AddTransaction : ICommand
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly long _accountId;
    private readonly ICommandResult<long> _command;

    public AddTransaction(IAccountRepository accountRepository, long accountId, ICommandResult<long> command, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _accountId = accountId;
        _command = command;
        _transactionRepository = transactionRepository;
    }

    public async Task Execute()
    {
        try
        {
            await _command.Execute().ConfigureAwait(false);
        }
        catch (Exception)
        {
            throw;
        }

        Account? account = await _accountRepository.GetAccountById(_accountId).ConfigureAwait(false);
        if (account is null)
        {
            throw new EmptyQueryAnswerException(nameof(account));
        }

        await _transactionRepository.AddTransaction(account.Id, account.Balance).ConfigureAwait(false);
    }
}