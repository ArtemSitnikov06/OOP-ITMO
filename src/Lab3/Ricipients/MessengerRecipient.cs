using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messanger;

namespace Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

public class MessengerRecipient : IRecipient
{
    private readonly List<Message> _messages;

    private readonly IMessenger _messenger;

    public MessengerRecipient(IMessenger messenger)
    {
        _messages = new List<Message>();
        _messenger = messenger;
    }

    public Message GetCurrentMessage()
    {
        return _messages.Last();
    }

    public void SendMessage()
    {
        if (_messages.Count != 0)
        {
            _messenger.ShowMessage(GetCurrentMessage().Body);
        }
    }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message);
    }
}