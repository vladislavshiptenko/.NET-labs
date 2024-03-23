using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public interface IParserFlags
{
    public void Parse(IEnumerator<string> commandPart, ICommandBuilder commandBuilder);
    public void AddNext(IParserFlags parserFlags);
}