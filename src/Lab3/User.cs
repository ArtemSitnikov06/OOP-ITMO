using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class User
{
    public int Id { get; private set; }

    private readonly List<UserMessage> _messages;

    public User(int id)
    {
        Id = id;
        _messages = new List<UserMessage>();
    }

    public void RecieveMessage(Message message)
    {
        _messages.Add(new UserMessage(message));
    }

    public IReadOnlyList<UserMessage> Messages => _messages.AsReadOnly();

    public UserMessage GetLastMessage()
    {
        return _messages.Last();
    }

    public IMarkMessageResult MarkAsRead()
    {
        UserMessage lastMessage = _messages.Last();
        if (lastMessage.Status == MessageStatus.NotCheck)
        {
            lastMessage.Status = MessageStatus.Check;
            return new SuccesMarkMessage();
        }

        return new FailMarkMessage();
    }
}