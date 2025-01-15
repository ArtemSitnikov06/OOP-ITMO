namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public class FailChangeSubjectAuthor : IChangeResult
{
    public bool IsValid { get; }

    public string Message { get; }

    public FailChangeSubjectAuthor()
    {
        Message = "Fail : You cant change subject if you are not author";
        IsValid = false;
    }

    public string GetResultMessage()
    {
        return Message;
    }
}