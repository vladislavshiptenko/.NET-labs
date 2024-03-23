using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class FileShowParser : ParserCommandBase
{
    private readonly IParserFlags _parserFlags;

    public FileShowParser(IParserFlags parserFlags)
    {
        _parserFlags = parserFlags;
    }

    public override ICommand Parse(IEnumerator<string> commandPart)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (commandPart.MoveNext() && commandPart.Current == "file" && commandPart.MoveNext() && commandPart.Current == "show")
        {
            var builder = new FileShowCommandBuilder();
            if (!commandPart.MoveNext())
            {
                if (Next is null)
                {
                    throw new ParseArgumentException(nameof(commandPart));
                }

                commandPart.Reset();
                return Next.Parse(commandPart);
            }

            builder.WithPath(commandPart.Current);
            _parserFlags.Parse(commandPart, builder);

            return builder.Build();
        }
        else
        {
            if (Next is null)
            {
                throw new ParseArgumentException(nameof(commandPart));
            }

            commandPart.Reset();
            return Next.Parse(commandPart);
        }
    }
}