namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public class FailChangeMaterialAuthor : IChangeResult
{
    public bool IsValid { get; }

    public string Message { get; }

    public FailChangeMaterialAuthor()
    {
        IsValid = false;
        Message = "Fail: You cant change material if you are not author";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}