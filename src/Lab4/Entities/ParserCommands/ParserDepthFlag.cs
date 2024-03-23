using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class ParserDepthFlag : ParserFlagsBase
{
    public override void Parse(IEnumerator<string> commandPart, ICommandBuilder commandBuilder)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (!commandPart.MoveNext() || commandPart.Current != "-d")
        {
            throw new ParseArgumentException(nameof(commandPart));
        }

        if (!commandPart.MoveNext())
        {
            throw new ParseArgumentException(nameof(commandPart));
        }

        if (commandBuilder is TreeListCommandBuilder builder)
        {
            if (!int.TryParse(commandPart.Current, out int depth))
            {
                throw new ParseInvalidTypeException(nameof(depth));
            }

            builder.WithDepth(depth);
        }
        else
        {
            throw new InvalidBuilderException(nameof(builder));
        }
    }
}