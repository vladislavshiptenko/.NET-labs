using Core.Models.Transactions;
using Core.Repositories;

namespace Core.Services.TransactionServices;

public class GetAllTransactions : ICommandResult<IReadOnlyList<Transaction>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly long _accountId;

    public GetAllTransactions(ITransactionRepository transactionRepository, long accountId)
    {
        _transactionRepository = transactionRepository;
        _accountId = accountId;
    }

    public async Task<IReadOnlyList<Transaction>?> Execute()
    {
        return await _transactionRepository.GetAllTransactions(_accountId).ConfigureAwait(false);
    }
}