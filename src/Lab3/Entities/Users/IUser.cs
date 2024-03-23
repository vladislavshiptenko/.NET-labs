using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public interface IUser
{
    public void ReceiveMessage(Message message);
    public void MarkAsRead(Message message);
    public MessageStatus GetMessageStatus(Message message);
}