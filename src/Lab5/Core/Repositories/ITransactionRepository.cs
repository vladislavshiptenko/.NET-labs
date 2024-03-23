using Core.Models.Transactions;

namespace Core.Repositories;

public interface ITransactionRepository
{
    public Task AddTransaction(long accountId, long balance);
    public Task<IReadOnlyList<Transaction>> GetAllTransactions(long accountId);
}