using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;
using Xunit;

namespace Lab3.Tests;

public class SeventhTest
{
    [Fact]

    public void Scenario1()
    {
        var user = new User(1);

        var userRecipient1 = new UserRecipient(user);
        var userRecipient2 = new UserRecipient(user);

        var filteredRecipient = new FilterRecipientDecorator(userRecipient2, ImportanceLevel.High);

        var lowImportanceMessage = new Message("Low Importance", "This is a low importance message", ImportanceLevel.Low);

        var topic1 = new Topic("low level");
        topic1.AddRecipient(userRecipient1);
        topic1.AddRecipient(filteredRecipient);
        topic1.SendMessage(lowImportanceMessage);

        userRecipient1.SendMessage();
        filteredRecipient.SendMessage();

        Assert.Single(user.Messages);
    }
}