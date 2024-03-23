using Core.Models.Transactions;
using Core.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;
#pragma warning disable CA2007
#pragma warning disable CA2000

namespace DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddTransaction(long accountId, long balance)
    {
        const string sql = """
                           insert into history (account_id, balance) values (:accountId, :balance)
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("accountId", accountId).AddParameter("balance", balance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<Transaction>> GetAllTransactions(long accountId)
    {
        const string sql = """
                           select account_id, balance
                           from history
                           where account_id=:accountId
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection).AddParameter("accountId", accountId);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        var transactions = new List<Transaction>();
        while (true)
        {
            bool hasNext = await reader.ReadAsync().ConfigureAwait(false);
            if (!hasNext)
            {
                break;
            }

            transactions.Add(new Transaction(reader.GetInt64(0), reader.GetInt64(1)));
        }

        return transactions;
    }
}