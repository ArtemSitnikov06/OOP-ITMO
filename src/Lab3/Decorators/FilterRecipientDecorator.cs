using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Ricipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Decorators;

public class FilterRecipientDecorator : BaseRecipientDecorator
{
    private readonly ImportanceLevel _minImportance;

    public FilterRecipientDecorator(IRecipient recipient, ImportanceLevel lev) : base(recipient)
    {
        _minImportance = lev;
    }

    public override void ReceiveMessage(Message message)
    {
        if (message.ImportanceLevel >= _minImportance)
        {
            base.ReceiveMessage(message);
        }
    }
}