using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeMessenger : IAddressee
{
    private readonly IMessenger _messenger;

    public AddresseeMessenger(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messenger.ReceiveMessage(message.Title + "\n" + message.Text);
    }
}