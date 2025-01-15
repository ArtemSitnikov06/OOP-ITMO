using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messanger;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class SixthTest
{
    [Fact]

    public void Scenario1()
    {
        var messengerMock = new Mock<IMessenger>();
        var messengerRecipient = new MessengerRecipient(messengerMock.Object);

        var message = new Message("Test Header", "Test Body", ImportanceLevel.Medium);

        var topic = new Topic("name");
        topic.AddRecipient(messengerRecipient);

        topic.SendMessage(message);

        messengerRecipient.SendMessage();

        messengerMock.Verify(
            messenger => messenger.ShowMessage(It.Is<string>(s => s == message.Body)),
            Times.Once);
    }
}