using Itmo.ObjectOrientedProgramming.Lab3.Entities.TelegramAPI;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class TelegramMessenger : IMessenger
{
    private readonly ITelegram _telegram;

    public TelegramMessenger(ITelegram telegram)
    {
        _telegram = telegram;
    }

    public void ReceiveMessage(string message)
    {
        _telegram.PostItem(message);
    }
}