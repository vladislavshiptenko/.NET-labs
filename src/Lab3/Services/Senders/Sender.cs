using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Senders;

public class Sender : ISender
{
    private ICollection<ITopic> _topics;

    public Sender(ICollection<ITopic> topics)
    {
        _topics = topics;
    }

    public void SendMessageToTopic(Message message, ITopic topic)
    {
        ITopic? foundTopic;

        try
        {
            foundTopic = _topics.First(t => t == topic);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Topic doesn't exist");
            throw;
        }

        foundTopic.SendMessage(message);
    }
}