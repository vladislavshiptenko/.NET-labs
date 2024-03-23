using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public interface IParser
{
    public ICommand Parse(string command);
}