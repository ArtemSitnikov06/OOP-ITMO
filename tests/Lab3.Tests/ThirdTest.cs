﻿using Itmo.ObjectOrientedProgramming.Lab3;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Results;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;
using Xunit;

namespace Lab3.Tests;

public class ThirdTest
{
    [Fact]
    public void Scenario1()
    {
        var message = new Message("aaaaa", "aaaaa", ImportanceLevel.Low);
        var user = new User(1);
        var userRec = new UserRecipient(user);
        var topic = new Topic("topic");
        topic.AddRecipient(userRec);

        topic.SendMessage(message);
        userRec.SendMessage();
        IMarkMessageResult check1 = user.MarkAsRead();
        Assert.True(check1.Succes, check1.Message);
        IMarkMessageResult check2 = user.MarkAsRead();
        Assert.False(check2.Succes, check2.Message);
    }
}