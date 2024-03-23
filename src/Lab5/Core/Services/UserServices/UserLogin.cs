using Core.Exceptions;
using Core.Models.Users;
using Core.Repositories;

namespace Core.Services.UserServices;

public class UserLogin : ICommand
{
    private readonly IUserRepository _userRepository;
    private readonly string username;
    private readonly string password;

    public UserLogin(string username, string password, IUserRepository userRepository)
    {
        this.username = username;
        this.password = password;
        _userRepository = userRepository;
    }

    public async Task Execute()
    {
        UserData? user = await _userRepository.GetUserDataByUsername(username).ConfigureAwait(false);

        if (user is null)
        {
            throw new LoginException("Invalid login");
        }

        if (user.Password != password)
        {
            throw new LoginException("Invalid password");
        }
    }
}