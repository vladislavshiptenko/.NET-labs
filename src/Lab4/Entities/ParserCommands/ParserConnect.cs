using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class ParserConnect : ParserCommandBase
{
    private readonly IParserFlags _flagsParser;

    public ParserConnect(IParserFlags flagsParser)
    {
        _flagsParser = flagsParser;
    }

    public override ICommand Parse(IEnumerator<string> commandPart)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (commandPart.MoveNext() && commandPart.Current == "connect")
        {
            var builder = new ConnectCommandBuilder();
            if (!commandPart.MoveNext())
            {
                if (Next is null)
                {
                    throw new ParseArgumentException(nameof(commandPart));
                }

                commandPart.Reset();
                return Next.Parse(commandPart);
            }

            builder.WithAddress(commandPart.Current);
            _flagsParser.Parse(commandPart, builder);

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