using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseePriorityChecker : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly MessagePriority _acceptableMessagePriority;

    public AddresseePriorityChecker(IAddressee addressee, MessagePriority acceptableMessagePriority)
    {
        _addressee = addressee;
        _acceptableMessagePriority = acceptableMessagePriority;
    }

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        if (_acceptableMessagePriority <= message.Priority)
        {
            _addressee.SendMessage(message);
        }
    }
}