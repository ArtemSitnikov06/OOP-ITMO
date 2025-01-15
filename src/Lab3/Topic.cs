using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    private readonly List<IRecipient> _recipients;

    public string Name { get; private set; }

    public Topic(string name)
    {
        Name = name;
        _recipients = new List<IRecipient>();
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}