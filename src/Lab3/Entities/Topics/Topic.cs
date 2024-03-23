using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic : ITopic
{
    private readonly IAddressee _addressee;

    public Topic(IAddressee addressee, string name)
    {
        _addressee = addressee;
        Name = name;
    }

    public string Name { get; }

    public void SendMessage(Message message)
    {
        _addressee.SendMessage(message);
    }
}