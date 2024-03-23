using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class Parser : IParser
{
    private readonly IParserCommand _parserCommand;

    public Parser(IParserCommand parserCommand)
    {
        _parserCommand = parserCommand;
    }

    public ICommand Parse(string command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        IList<string> commandParts = command.Split(' ');
        return _parserCommand.Parse(commandParts.GetEnumerator());
    }
}