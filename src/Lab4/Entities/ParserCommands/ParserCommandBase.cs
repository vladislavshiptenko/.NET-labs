using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public abstract class ParserCommandBase : IParserCommand
{
    protected IParserCommand? Next { get; private set; }

    public void AddNext(IParserCommand parserCommand)
    {
        if (Next is null)
        {
            Next = parserCommand;
        }
        else
        {
            Next.AddNext(parserCommand);
        }
    }

    public abstract ICommand Parse(IEnumerator<string> commandPart);
}