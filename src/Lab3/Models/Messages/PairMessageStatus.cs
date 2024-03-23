namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

public class PairMessageStatus
{
    public PairMessageStatus(Message message, MessageStatus status)
    {
        Message = message;
        Status = status;
    }

    public Message Message { get; }
    public MessageStatus Status { get; private set; }

    public void MarkAsRead()
    {
        Status = MessageStatus.Read;
    }
}