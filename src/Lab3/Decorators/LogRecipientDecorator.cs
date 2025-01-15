using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class LogRecipientDecorator : BaseRecipientDecorator
{
    private readonly ILogger _logger;

    public LogRecipientDecorator(IRecipient recipient, ILogger logger) : base(recipient)
    {
        _logger = logger;
    }

    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        _logger.Log($"{DateTime.Now}: Header: {message.Header}. Body: {message.Body}");
    }
}