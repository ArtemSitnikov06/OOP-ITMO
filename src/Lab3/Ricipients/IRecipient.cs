using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

public interface IRecipient
{
    public void ReceiveMessage(Message message);

    public void SendMessage();
}