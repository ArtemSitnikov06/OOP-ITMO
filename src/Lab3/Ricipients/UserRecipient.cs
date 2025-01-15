using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

public class UserRecipient : IRecipient
{
    private readonly List<Message> _messages;

    private readonly User _user;

    public UserRecipient(User user)
    {
        _user = user;
        _messages = new List<Message>();
    }

    public Message GetCurrentMessage()
    {
        return _messages.Last();
    }

    public void SendMessage()
    {
        if (_messages.Count != 0)
        {
            _user.RecieveMessage(GetCurrentMessage());
        }
    }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message);
    }
}