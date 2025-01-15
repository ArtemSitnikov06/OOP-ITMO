namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public class SuccesCheckPoints : ICheckPointResult
{
    public bool Succes { get; }

    public string Message { get; }

    public SuccesCheckPoints()
    {
        Succes = true;
        Message = "Summ of labs == 100";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}