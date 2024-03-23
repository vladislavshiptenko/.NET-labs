using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Senders;

public interface ISender
{
    public void SendMessageToTopic(Message message, ITopic topic);
}