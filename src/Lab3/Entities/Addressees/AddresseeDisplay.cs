using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _display.ReceiveMessage(message.Title + "\n" + message.Text);
    }
}