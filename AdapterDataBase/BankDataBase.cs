using Npgsql;
using Ports;

namespace AdapterDataBase;

#pragma warning disable CA2007
public class BankDataBase : IBankDatabase
{
    private readonly string _connectionString;

    public BankDataBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task CreateAccountAsync(BankAccountDTO account)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        using var command = new NpgsqlCommand("INSERT INTO BankAccounts (AccountNumber, PinCode, Balance) VALUES (@AccountNumber, @PinCode, @Balance)", connection);
        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
        command.Parameters.AddWithValue("@PinCode", account.PinCode);
        command.Parameters.AddWithValue("@Balance", account.Balance);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<BankAccountDTO?> GetAccountAsync(int accountNumber, int pinCode)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand("select AccountNumber, PinCode, Balance from BankAccounts where AccountNumber = @AccountNumber and PinCode = @PinCode", connection);
        command.Parameters.AddWithValue("@AccountNumber", accountNumber);
        command.Parameters.AddWithValue("@PinCode", pinCode);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            var bankAcc = new BankAccountDTO
            {
                AccountNumber = reader.GetInt32(0),
                PinCode = reader.GetInt32(1),
                Balance = reader.GetDecimal(2),
            };
            return bankAcc;
        }

        return null;
    }

    public async Task UpdateAccountAsync(BankAccountDTO account)
    {
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand("UPDATE BankAccounts SET Balance = @Balance WHERE AccountNumber = @AccountNumber", connection);

        command.Parameters.AddWithValue("@Balance", account.Balance);
        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
        await command.ExecuteNonQueryAsync();
    }

    public async Task AddTransactionAsync(BankAccountDTO account, TransactionDTO transaction)
    {
        if (transaction is null)
        {
            throw new ArgumentNullException(nameof(transaction), "The account cannot be null.");
        }

        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand("INSERT INTO Transactions (AccountNumber, Type, Amount, DateTime) VALUES (@AccountNumber, @Type, @Amount, @DateTime)", connection);

        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
        command.Parameters.AddWithValue("@Type", transaction.Type.ToString());
        command.Parameters.AddWithValue("@Amount", transaction.Amount);
        command.Parameters.AddWithValue("@DateTime", transaction.DateTime);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<IReadOnlyList<TransactionDTO>> GetTransactionHistoryAsync(BankAccountDTO account)
    {
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        var transactions = new List<TransactionDTO>();

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        using var command = new NpgsqlCommand("SELECT Type, Amount, DateTime, id FROM Transactions WHERE AccountNumber = @AccountNumber", connection);
        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var transactionType = (TransactionDTO.TransactionType)Enum.Parse(typeof(TransactionDTO.TransactionType), reader.GetString(0));

            var transaction = new TransactionDTO
            {
                Type = transactionType,
                Amount = reader.GetDecimal(1),
                DateTime = reader.GetDateTime(2),
                Id = reader.GetInt32(3),
            };

            transactions.Add(transaction);
        }

        return transactions;
    }
}