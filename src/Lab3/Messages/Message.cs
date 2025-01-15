namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IPrototype<Message>
{
    public string Header { get; }

    public string Body { get; }

    public MessageStatus MessageStatus { get; set; }

    public ImportanceLevel ImportanceLevel { get; }

    public Message(string header, string body, ImportanceLevel importanceLev)
    {
        Header = header;
        Body = body;
        ImportanceLevel = importanceLev;
        MessageStatus = MessageStatus.NotCheck;
    }

    public Message Clone()
    {
        return new Message(Header, Body, ImportanceLevel);
    }
}