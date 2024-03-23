using Core.Models.Users;

namespace Core.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsername(string username);
    Task<IReadOnlyList<User>> GetAllUsers();
    Task CreateUser(string username, string password, string roleName);
    Task<int> GetRoleByName(string roleName);
    public Task<UserData?> GetUserDataByUsername(string username);
}