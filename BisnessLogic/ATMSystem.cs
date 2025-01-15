using Ports;

namespace BisnessLogic;

#pragma warning disable CA2007
public class ATMSystem
{
    private readonly IBankDatabase _bankDatabase;

    public ATMSystem(IBankDatabase bankDatabase)
    {
        _bankDatabase = bankDatabase;
    }

    public async Task CreateAccount(int bankAccount, int pin)
    {
        var bankAcc = new BankAccount(bankAccount, pin);
        var bankAccDto = new BankAccountDTO
        {
            AccountNumber = bankAccount,
            PinCode = pin,
            Balance = bankAcc.Balance,
        };

        await _bankDatabase.CreateAccountAsync(bankAccDto);
    }

    public async Task<decimal> CheckBalance(int bankAccount, int pin)
    {
        BankAccountDTO? accountDto = await _bankDatabase.GetAccountAsync(bankAccount, pin);
        return accountDto?.Balance ?? 0;
    }

    public async Task<bool> Withdraw(int bankAccount, decimal amount, int pin)
    {
        if (amount < 0)
        {
            return false;
        }

        BankAccountDTO? accountDto = await _bankDatabase.GetAccountAsync(bankAccount, pin);
        if (accountDto != null && accountDto.Balance >= amount)
        {
            var account = new BankAccount(accountDto.AccountNumber, accountDto.PinCode, accountDto.Balance);
            account.UpdateBalance(account.Balance - amount);
            accountDto.Balance = account.Balance;
            await _bankDatabase.UpdateAccountAsync(accountDto);

            var transactionDto = new TransactionDTO
            {
                Type = TransactionDTO.TransactionType.Withdraw,
                Amount = amount,
                DateTime = DateTime.Now,
            };
            await _bankDatabase.AddTransactionAsync(accountDto, transactionDto);
            return true;
        }

        return false;
    }

    public async Task Deposit(int bankAccount, decimal amount, int pin)
    {
        if (amount < 0)
        {
            return;
        }

        BankAccountDTO? accountDto = await _bankDatabase.GetAccountAsync(bankAccount, pin);

        if (accountDto != null)
        {
            var account = new BankAccount(accountDto.AccountNumber, accountDto.PinCode, accountDto.Balance);
            account.UpdateBalance(account.Balance + amount);
            accountDto.Balance = account.Balance;
            await _bankDatabase.UpdateAccountAsync(accountDto);

            var transactionDto = new TransactionDTO
            {
                Type = TransactionDTO.TransactionType.Deposit,
                Amount = amount,
                DateTime = DateTime.Now,
            };

            await _bankDatabase.AddTransactionAsync(accountDto, transactionDto);
        }
    }

    public async Task<IReadOnlyList<TransactionDTO>> GetTransactionHistory(int bankAccount, int pin)
    {
        BankAccountDTO? accountDto = await _bankDatabase.GetAccountAsync(bankAccount, pin);
        if (accountDto != null)
        {
            return await _bankDatabase.GetTransactionHistoryAsync(accountDto);
        }

        throw new KeyNotFoundException();
    }
}
