using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class AddresseeLogger : IAddressee
{
    private readonly ILogger _logger;
    private readonly IAddressee _decoratee;

    public AddresseeLogger(IAddressee decoratee, ILogger logger)
    {
        _decoratee = decoratee;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _logger.Log(MessageToLogText(message));
        _decoratee.SendMessage(message);
    }

    private static string MessageToLogText(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return "Addresse receive message:\n" + "Message title: " + message.Title + "\n" + "Message text: " +
               message.Text + "\n";
    }
}