namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public class SuccesChangeByAuthor : IChangeResult
{
    public bool IsValid { get; }

    public string Message { get; }

    public SuccesChangeByAuthor()
    {
        IsValid = true;
        Message = "Succes Changed";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}