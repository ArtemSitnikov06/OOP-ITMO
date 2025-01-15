using BisnessLogic;
using Moq;
using Ports;
using Xunit;

namespace Lab5.Tests;

public class Test
{
    [Fact]
    public async Task SuccesWithdraw()
    {
        int bankAcc = 12345;
        decimal balance = 100M;
        decimal withdrawAmount = 50M;
        int pinCode = 0000;

        var account = new BankAccountDTO
        {
            AccountNumber = bankAcc,
            PinCode = pinCode,
            Balance = balance,
        };

        var mockRepoDataBase = new Mock<IBankDatabase>();

        mockRepoDataBase.Setup(r => r.GetAccountAsync(bankAcc, pinCode)).ReturnsAsync(account);

        var atm = new ATMSystem(mockRepoDataBase.Object);
        var auth = new AuthenticateSystem(mockRepoDataBase.Object);
        var atmService = new ATMService(atm, auth);

        bool result = await atmService.WithdrawAsync(bankAcc, withdrawAmount, pinCode);

        Assert.True(result);
        Assert.Equal(balance - withdrawAmount, account.Balance);
    }

    [Fact]

    public async Task UnSucceedWithdraw()
    {
        int bankAcc = 12345;
        decimal balance = 100M;
        decimal withdrawAmount = 500M;
        int pinCode = 0000;

        var account = new BankAccountDTO
        {
            AccountNumber = bankAcc,
            PinCode = pinCode,
            Balance = balance,
        };

        var mockRepoDataBase = new Mock<IBankDatabase>();

        mockRepoDataBase.Setup(r => r.GetAccountAsync(bankAcc, pinCode)).ReturnsAsync(account);

        var atm = new ATMSystem(mockRepoDataBase.Object);
        var auth = new AuthenticateSystem(mockRepoDataBase.Object);
        var atmService = new ATMService(atm, auth);

        bool result = await atmService.WithdrawAsync(bankAcc, withdrawAmount, pinCode);

        Assert.False(result);
    }

    [Fact]

    public async Task Deposit()
    {
        int bankAcc = 12345;
        decimal balance = 100M;
        decimal depositAmount = 500M;
        decimal totalAmount = depositAmount + balance;
        int pinCode = 0000;

        var account = new BankAccountDTO
        {
            AccountNumber = bankAcc,
            PinCode = pinCode,
            Balance = balance,
        };

        var mockRepoDataBase = new Mock<IBankDatabase>();

        mockRepoDataBase.Setup(r => r.GetAccountAsync(bankAcc, pinCode)).ReturnsAsync(account);

        var atm = new ATMSystem(mockRepoDataBase.Object);
        var auth = new AuthenticateSystem(mockRepoDataBase.Object);
        var atmService = new ATMService(atm, auth);

        await atmService.DepositAsync(bankAcc, depositAmount, pinCode);

        Assert.Equal(account.Balance, totalAmount);
    }
}