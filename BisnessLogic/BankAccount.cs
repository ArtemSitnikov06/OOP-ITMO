namespace BisnessLogic;

public class BankAccount
{
    public BankAccount(int accountNumber, int pinCode, decimal balance = 0)
    {
        AccountNumber = accountNumber;
        PinCode = pinCode;
        Balance = balance;
    }

    public int AccountNumber { get; private set; }

    public int PinCode { get; private set; }

    public decimal Balance { get; private set; }

    public void UpdateBalance(decimal newBalance)
    {
        Balance = newBalance;
    }
}