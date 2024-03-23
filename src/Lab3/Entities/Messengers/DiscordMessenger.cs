using Itmo.ObjectOrientedProgramming.Lab3.Entities.DiscordAPI;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

public class DiscordMessenger : IMessenger
{
    private readonly IDiscordClient _discordClient;

    public DiscordMessenger(IDiscordClient discordClient)
    {
        _discordClient = discordClient;
    }

    public void ReceiveMessage(string message)
    {
        _discordClient.SendMessage(message);
    }
}