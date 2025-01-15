namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class UserMessage
{
    public Message Message { get; }

    public MessageStatus Status { get; set; }

    public UserMessage(Message message)
    {
        Message = message;
        Status = MessageStatus.NotCheck;
    }
}