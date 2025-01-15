namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public class SuccesMarkMessage : IMarkMessageResult
{
    public bool Succes { get; }

    public string Message { get; }

    public SuccesMarkMessage()
    {
        Succes = true;
        Message = "Success of mark message as read";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}
