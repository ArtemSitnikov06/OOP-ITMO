namespace Itmo.ObjectOrientedProgramming.Lab4.CommandReader;

public class ConsoleCommandReader : ICommandReader
{
    public string ReadCommand()
    {
        string? command = Console.ReadLine();
        if (string.IsNullOrEmpty(command))
        {
            throw new InvalidOperationException("Command cannot be empty.");
        }

        return command.Trim();
    }
}