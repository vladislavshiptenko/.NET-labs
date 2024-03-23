using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.DiscordAPI;

public class DiscordClient : IDiscordClient
{
    public void SendMessage(string message)
    {
        Console.WriteLine("Discord");
        Console.WriteLine(message);
    }
}