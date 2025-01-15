using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.CommandReader;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;
using Moq;
using Xunit;

namespace Lab4.Tests;

public class Test
{
    [Fact]
    public void CheckConnectCommand()
    {
        var commandReaderMock = new Mock<ICommandReader>();
        string[] collection = { "*", "+", "--", "connect C:\\User\\New\\Desktop -m local" };
        var commands = new Queue<string>(collection);

        commandReaderMock
            .Setup(c => c.ReadCommand())
            .Returns(() => commands.Count > 0 ? commands.Dequeue() : "disconnect");

        var loggerMock = new Mock<ILogger>();

        var dir = new AbsoluteDirectory();

        var settings = new TreeSettings(commandReaderMock.Object, loggerMock.Object);

        var fs = new FileSystem(commandReaderMock.Object, loggerMock.Object, dir, settings);

        fs.ProccessComand();

        loggerMock.Verify(l => l.Log("C:\\User\\New\\Desktop not found"), Times.Once);
    }

    [Fact]
    public void CheckListCommans()
    {
        var commandReaderMock = new Mock<ICommandReader>();
        string[] collection = { "*", "+", "--", "connect C:\\Users\\New\\Desktop -m local", "tree list testtt -d 1.2" };
        var commands = new Queue<string>(collection);

        commandReaderMock
            .Setup(c => c.ReadCommand())
            .Returns(() => commands.Count > 0 ? commands.Dequeue() : "disconnect");

        var loggerMock = new Mock<ILogger>();

        var dir = new AbsoluteDirectory();

        var settings = new TreeSettings(commandReaderMock.Object, loggerMock.Object);

        var fs = new FileSystem(commandReaderMock.Object, loggerMock.Object, dir, settings);

        fs.ProccessComand();

        loggerMock.Verify(l => l.Log("Depth must be equal integer"), Times.Once);
    }
}