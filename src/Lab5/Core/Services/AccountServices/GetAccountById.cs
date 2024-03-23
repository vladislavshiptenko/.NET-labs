using Core.Models.Accounts;
using Core.Repositories;

namespace Core.Services.AccountServices;

public class GetAccountById : ICommandResult<Account>
{
    private readonly IAccountRepository _accountRepository;
    private readonly long _id;

    public GetAccountById(IAccountRepository accountRepository, long id)
    {
        _accountRepository = accountRepository;
        _id = id;
    }

    public async Task<Account?> Execute()
    {
        return await _accountRepository.GetAccountById(_id).ConfigureAwait(true);
    }
}