namespace Itmo.ObjectOrientedProgramming.Lab2.Results;

public class FailCheckPoints : ICheckPointResult
{
    public bool Succes { get; }

    public string Message { get; }

    public FailCheckPoints()
    {
        Succes = false;
        Message = "Summ of Labs must be == 100";
    }

    public string GetResultMessage()
    {
        return Message;
    }
}