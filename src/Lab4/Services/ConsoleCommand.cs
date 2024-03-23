using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public class ConsoleCommand : IConsole
{
    private readonly IParser _parser;
    private readonly IContext _context;

    public ConsoleCommand(IParser parser, IContext context)
    {
        _parser = parser;
        _context = context;
    }

    public void ExecuteCommand()
    {
        string? commandText = Console.ReadLine();
        ICommand command = _parser.Parse(commandText ?? throw new ArgumentNullException(nameof(commandText)));
        command.Execute(_context);
    }
}