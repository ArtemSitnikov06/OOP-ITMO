using Itmo.ObjectOrientedProgramming.Lab4.CommandReader;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ConsoleApp
{
    public static void Run()
    {
        ILogger logger = new ConsoleLogger();
        ICommandReader commandReader = new ConsoleCommandReader();
        var fs = new FileSystem(commandReader, logger, new AbsoluteDirectory(), new TreeSettings(commandReader, logger));
        fs.ProccessComand();
    }
}