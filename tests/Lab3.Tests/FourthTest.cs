using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class FourthTest
{
    [Fact]
    public void Scenario1()
    {
        var message = new Message("header", "body", ImportanceLevel.Low);
        var messengerRecMock = new Mock<IRecipient>();
        var filter = new FilterRecipientDecorator(messengerRecMock.Object, ImportanceLevel.High);
        var topic = new Topic("name");
        topic.AddRecipient(filter);
        topic.SendMessage(message);
        messengerRecMock.Verify(r => r.ReceiveMessage(It.IsAny<Message>()), Times.Never);
    }
}