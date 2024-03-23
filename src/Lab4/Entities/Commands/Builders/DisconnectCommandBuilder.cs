namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public ICommand Build()
    {
        return new DisconnectCommand();
    }
}