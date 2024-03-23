using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public abstract class ParserFlagsBase : IParserFlags
{
    protected IParserFlags? Next { get; private set; }

    public abstract void Parse(IEnumerator<string> commandPart, ICommandBuilder commandBuilder);
    public void AddNext(IParserFlags parserFlags)
    {
        if (Next is null)
        {
            Next = parserFlags;
        }
        else
        {
            Next.AddNext(parserFlags);
        }
    }
}