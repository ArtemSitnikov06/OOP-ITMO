namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public class FailChangeLabAuthor : IChangeResult
{
    public bool IsValid { get; }

    public string Message { get; }

    public FailChangeLabAuthor()
    {
        IsValid = false;
        Message = "Fail: You cant change lab if you are not author";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}