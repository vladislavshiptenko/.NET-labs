using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public interface ITopic
{
    public string Name { get; }
    public void SendMessage(Message message);
}