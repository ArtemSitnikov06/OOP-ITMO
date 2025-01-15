namespace Ports;

public class TransactionDTO
{
    public enum TransactionType
    {
        Deposit,
        Withdraw,
    }

    public TransactionType Type { get; set; }

    public decimal Amount { get; set; }

    public DateTime DateTime { get; set; }

    public int Id { get; set; }
}