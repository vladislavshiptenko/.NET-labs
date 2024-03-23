using Core.Models.Users;
using Core.Repositories;

namespace Core.Services.UserServices;

public class GetAllUsers : ICommandResult<IReadOnlyList<User>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<User>?> Execute()
    {
        return await _userRepository.GetAllUsers().ConfigureAwait(false);
    }
}