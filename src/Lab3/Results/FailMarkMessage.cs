namespace Itmo.ObjectOrientedProgramming.Lab3.Results;

public class FailMarkMessage : IMarkMessageResult
{
    public bool Succes { get; }

    public string Message { get; }

    public FailMarkMessage()
    {
        Succes = false;
        Message = "You cant mark message as read becuse he is already read";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}