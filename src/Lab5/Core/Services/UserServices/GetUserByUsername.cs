using Core.Exceptions;
using Core.Models.Users;
using Core.Repositories;

namespace Core.Services.UserServices;

public class GetUserByUsername : ICommandResult<User>
{
    private readonly IUserRepository _userRepository;
    private readonly string _username;

    public GetUserByUsername(IUserRepository userRepository, string username)
    {
        _userRepository = userRepository;
        _username = username;
    }

    public async Task<User?> Execute()
    {
        User? user = await _userRepository.GetUserByUsername(_username).ConfigureAwait(false);

        if (user is null)
        {
            throw new EmptyQueryAnswerException(nameof(user));
        }

        return await _userRepository.GetUserByUsername(_username).ConfigureAwait(false);
    }
}