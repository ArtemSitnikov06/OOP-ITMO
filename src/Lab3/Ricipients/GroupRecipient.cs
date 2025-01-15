using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients;

    public GroupRecipient()
    {
        _recipients = new List<IRecipient>();
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IRecipient rec in _recipients)
        {
            rec.ReceiveMessage(message);
        }
    }

    public void SendMessage()
    {
        foreach (IRecipient rec in _recipients)
        {
            rec.SendMessage();
        }
    }
}