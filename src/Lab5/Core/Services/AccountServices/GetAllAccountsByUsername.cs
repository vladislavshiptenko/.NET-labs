using Core.Models.Accounts;
using Core.Repositories;

namespace Core.Services.AccountServices;

public class GetAllAccountsByUsername : ICommandResult<IReadOnlyList<Account>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly string _username;

    public GetAllAccountsByUsername(IAccountRepository accountRepository, string username)
    {
        _accountRepository = accountRepository;
        _username = username;
    }

    public async Task<IReadOnlyList<Account>?> Execute()
    {
        return await _accountRepository.GetAllAccountsByUsername(_username).ConfigureAwait(false);
    }
}