using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class BaseRecipientDecorator : IRecipient
{
    private readonly IRecipient _recipient;

    public BaseRecipientDecorator(IRecipient recipient)
    {
        _recipient = recipient;
    }

    public virtual void ReceiveMessage(Message message)
    {
        _recipient.ReceiveMessage(message);
    }

    public void SendMessage()
    {
        _recipient.SendMessage();
    }
}
