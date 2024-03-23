using Core.Models.Users;
using Core.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
#pragma warning disable CA2007
#pragma warning disable CA2000

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        const string sql = """
                           select id, username
                           from users
                           where username=:username
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("username", username);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
        {
            return null;
        }

        return new User(reader.GetInt64(0), reader.GetString(1));
    }

    public async Task<int> GetRoleByName(string roleName)
    {
        const string sql = """
                           select id
                           from user_role
                           where role_name=:role_name
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("role_name", roleName);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
        {
            return 0;
        }

        return reader.GetInt32(0);
    }

    public async Task<UserData?> GetUserDataByUsername(string username)
    {
        const string sql = """
                           select username, password, role_name
                           from users
                           inner join user_role as ur on ur.id=user_role_id
                           where username=:username
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("username", username);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync().ConfigureAwait(false))
        {
            return null;
        }

        return new UserData(reader.GetString(0), reader.GetString(1), reader.GetString(2));
    }

    public async Task<IReadOnlyList<User>> GetAllUsers()
    {
        const string sql = """
                           select id, username
                           from users
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        var users = new List<User>();
        while (true)
        {
            bool hasNext = await reader.ReadAsync().ConfigureAwait(false);
            if (!hasNext)
            {
                break;
            }

            users.Add(new User(reader.GetInt64(0), reader.GetString(1)));
        }

        return users;
    }

    public async Task CreateUser(string username, string password, string roleName)
    {
        int role = await GetRoleByName(roleName);

        const string sql = """
                           insert into users (username, password, user_role_id) values (:username, :password, :user_role_id)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("username", username).AddParameter("password", password).AddParameter("user_role_id", role);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}