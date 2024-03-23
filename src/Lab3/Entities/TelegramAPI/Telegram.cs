using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.TelegramAPI;

public class Telegram : ITelegram
{
    public void PostItem(string item)
    {
        Console.WriteLine("Telegram");
        Console.WriteLine(item);
    }
}