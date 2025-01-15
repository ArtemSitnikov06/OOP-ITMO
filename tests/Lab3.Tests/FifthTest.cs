using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messanger;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class FifthTest
{
    [Fact]

    public void Scenario1()
    {
        var loggerMock = new Mock<ILogger>();
        var message = new Message("head", "body", ImportanceLevel.Low);
        var messengerRecipient = new MessengerRecipient(new Messenger(loggerMock.Object));
        var logRec = new LogRecipientDecorator(messengerRecipient, loggerMock.Object);
        var topic = new Topic("topic");
        topic.AddRecipient(logRec);
        topic.SendMessage(message);

        loggerMock.Verify(
            logger => logger.Log(
                It.Is<string>(s => s.Contains($"{DateTime.Now}") && s.Contains(message.Header) && s.Contains(message.Body))),
            Times.Once);
    }
}