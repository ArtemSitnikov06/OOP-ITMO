namespace Ports;

public interface IATMService
{
    Task CreateAccountAsync(int bankAccount, int pin);

    Task<decimal> CheckBalanceAsync(int bankAccount, int pin);

    Task<bool> WithdrawAsync(int bankAccount, decimal amount, int pin);

    Task DepositAsync(int bankAccount, decimal amount, int pin);

    Task<IReadOnlyList<TransactionDTO>> GetTransactionHistoryAsync(int bankAccount, int pin);

    Task<bool> AuthenticateAsync(int bankAccount, int pin);

    bool AuthenticateAdmin(string admPassword);
}