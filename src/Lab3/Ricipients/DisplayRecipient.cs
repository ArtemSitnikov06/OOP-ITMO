using Itmo.ObjectOrientedProgramming.Lab3.DisplayEntity;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

public class DisplayRecipient : IRecipient
{
    public IDisplay Display { get; }

    private readonly List<Message> _messages;

    public DisplayRecipient(IDisplay display)
    {
        Display = display;
        _messages = new List<Message>();
    }

    public Message GetCurrentMessage()
    {
        return _messages.Last();
    }

    public void SendMessage()
    {
        Display.ShowMessage(GetCurrentMessage().Body);
    }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(message);
    }
}
