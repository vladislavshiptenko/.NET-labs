using Core.Exceptions;
using Core.Models.Users;
using Core.Repositories;

namespace Core.Services.AccountServices;

public class CreateAccount : ICommand
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly string _username;

    public CreateAccount(IAccountRepository accountRepository, string username, IUserRepository userRepository)
    {
        _accountRepository = accountRepository;
        _username = username;
        _userRepository = userRepository;
    }

    public async Task Execute()
    {
        User? user = await _userRepository.GetUserByUsername(_username).ConfigureAwait(false);

        if (user is null)
        {
            throw new EmptyQueryAnswerException(nameof(user));
        }

        await _accountRepository.CreateAccount(user.Id).ConfigureAwait(false);
    }
}