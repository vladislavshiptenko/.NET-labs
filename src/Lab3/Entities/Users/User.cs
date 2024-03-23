using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IUser
{
    private readonly ICollection<PairMessageStatus> _messages;

    public User(ICollection<PairMessageStatus> messages)
    {
        _messages = messages;
    }

    public void ReceiveMessage(Message message)
    {
        _messages.Add(new PairMessageStatus(message, MessageStatus.Unread));
    }

    public void MarkAsRead(Message message)
    {
        PairMessageStatus? foundMessage;

        try
        {
            foundMessage = _messages.First(m => m.Message == message);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Message doesn't exist");
            throw;
        }

        if (foundMessage.Status is MessageStatus.Read)
        {
            throw new ReadMessageMarkAsReadException(nameof(message));
        }

        foundMessage.MarkAsRead();
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        PairMessageStatus? foundMessage;

        try
        {
            foundMessage = _messages.First(m => m.Message == message);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Message doesn't exist");
            throw;
        }

        return foundMessage.Status;
    }
}