using Core.Models.Accounts;
using Core.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
#pragma warning disable CA2007
#pragma warning disable CA2000

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Account?> GetAccountById(long id)
    {
        const string sql = """
                           select id, balance, user_id
                           from accounts
                           where id=:id
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("id", id);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (!await reader.ReadAsync().ConfigureAwait(false))
        {
            return null;
        }

        return new Account(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2));
    }

    public async Task<IReadOnlyList<Account>> GetAllAccountsByUsername(string username)
    {
        const string sql = """
                           select acc.id, balance, user_id
                           from accounts as acc
                           inner join users as u on u.id=user_id
                           where username=:username
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("username", username);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        var accounts = new List<Account>();
        while (true)
        {
            bool hasNext = await reader.ReadAsync().ConfigureAwait(false);
            if (!hasNext)
            {
                break;
            }

            accounts.Add(new Account(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2)));
        }

        return accounts;
    }

    public async Task CreateAccount(long userId)
    {
        const string sql = """
                           insert into accounts (balance, user_id) values (0, :userId)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("userId", userId);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task UpdateAccount(long accountId, long newBalance)
    {
        const string sql = """
                           update accounts SET balance=:newBalance WHERE id=:accountId
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("newBalance", newBalance).AddParameter("accountId", accountId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);
    }
}