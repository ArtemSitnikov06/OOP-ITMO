namespace BisnessLogic;

public class Transaction
{
    public Transaction(TransactionType type, decimal amount, DateTime dateTime)
    {
        Type = type;
        Amount = amount;
        DateTime = dateTime;
    }

    public enum TransactionType
    {
        Deposit,
        Withdraw,
    }

    public TransactionType Type { get; }

    public decimal Amount { get; }

    public DateTime DateTime { get; }

    public int Id { get; set; }
}