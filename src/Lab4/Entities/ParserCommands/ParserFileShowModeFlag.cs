using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Repositories;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class ParserFileShowModeFlag : ParserFlagsBase
{
    private readonly IFileShowModeRepository _repository;

    public ParserFileShowModeFlag(IFileShowModeRepository repository)
    {
        _repository = repository;
    }

    public override void Parse(IEnumerator<string> commandPart, ICommandBuilder commandBuilder)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (!commandPart.MoveNext() || commandPart.Current != "-m")
        {
            throw new ParseArgumentException(nameof(commandPart));
        }

        if (!commandPart.MoveNext())
        {
            throw new ParseArgumentException(nameof(commandPart));
        }

        if (commandBuilder is FileShowCommandBuilder builder)
        {
            builder.WithLogger(_repository.GetLogger(commandPart.Current));
        }
        else
        {
            throw new InvalidBuilderException(nameof(builder));
        }
    }
}