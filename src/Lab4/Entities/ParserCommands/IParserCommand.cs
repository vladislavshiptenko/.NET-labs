using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public interface IParserCommand
{
    public ICommand Parse(IEnumerator<string> commandPart);
    public void AddNext(IParserCommand parserCommand);
}