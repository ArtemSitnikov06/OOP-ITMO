using Ports;

namespace BisnessLogic;

#pragma warning disable CA2007
public class ATMService : IATMService
{
    private readonly ATMSystem _atmSystem;

    private readonly AuthenticateSystem _authenticateSystem;

    public ATMService(ATMSystem atmSystem, AuthenticateSystem authenticateSystem)
    {
        _atmSystem = atmSystem;
        _authenticateSystem = authenticateSystem;
    }

    public async Task CreateAccountAsync(int bankAccount, int pin)
    {
        await _atmSystem.CreateAccount(bankAccount, pin);
    }

    public async Task<decimal> CheckBalanceAsync(int bankAccount, int pin)
    {
        return await _atmSystem.CheckBalance(bankAccount, pin);
    }

    public async Task<bool> WithdrawAsync(int bankAccount, decimal amount, int pin)
    {
        return await _atmSystem.Withdraw(bankAccount, amount, pin);
    }

    public async Task DepositAsync(int bankAccount, decimal amount, int pin)
    {
        await _atmSystem.Deposit(bankAccount, amount, pin);
    }

    public async Task<IReadOnlyList<TransactionDTO>> GetTransactionHistoryAsync(int bankAccount, int pin)
    {
        return await _atmSystem.GetTransactionHistory(bankAccount, pin);
    }

    public async Task<bool> AuthenticateAsync(int bankAccount, int pin)
    {
        return await _authenticateSystem.AuthenticateUser(bankAccount, pin);
    }

    public bool AuthenticateAdmin(string admPassword)
    {
        return _authenticateSystem.AuthenticateAdmin(admPassword);
    }
}