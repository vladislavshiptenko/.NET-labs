using Core.Models.Accounts;

namespace Core.Repositories;

public interface IAccountRepository
{
    Task<Account?> GetAccountById(long id);
    Task<IReadOnlyList<Account>> GetAllAccountsByUsername(string username);
    Task CreateAccount(long userId);
    Task UpdateAccount(long accountId, long newBalance);
}