using Core.Exceptions;
using Core.Models.Users;
using Core.Repositories;

namespace Core.Services.UserServices;

public class CreateUser : ICommand
{
    private readonly IUserRepository _userRepository;
    private readonly string _username;
    private readonly string _password;
    private readonly string _userRole;

    public CreateUser(IUserRepository userRepository, string username, string password, string userRole)
    {
        _userRepository = userRepository;
        _username = username;
        _password = password;
        _userRole = userRole;
    }

    public async Task Execute()
    {
        User? user = await _userRepository.GetUserByUsername(_username).ConfigureAwait(false);

        if (user is not null)
        {
            throw new SameUsernameException(_username);
        }

        await _userRepository.CreateUser(_username, _password, _userRole).ConfigureAwait(false);
    }
}