namespace Ports;

public interface IBankDatabase
{
    Task CreateAccountAsync(BankAccountDTO account);

    Task<BankAccountDTO?> GetAccountAsync(int accountNumber, int pinCode);

    Task UpdateAccountAsync(BankAccountDTO account);

    Task AddTransactionAsync(BankAccountDTO account, TransactionDTO transaction);

    Task<IReadOnlyList<TransactionDTO>> GetTransactionHistoryAsync(BankAccountDTO account);
}
