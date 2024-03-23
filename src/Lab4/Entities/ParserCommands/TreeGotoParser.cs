using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class TreeGotoParser : ParserCommandBase
{
    public override ICommand Parse(IEnumerator<string> commandPart)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (commandPart.MoveNext() && commandPart.Current == "tree" && commandPart.MoveNext() && commandPart.Current == "goto")
        {
            if (!commandPart.MoveNext())
            {
                if (Next is null)
                {
                    throw new ParseArgumentException(nameof(commandPart));
                }

                commandPart.Reset();
                return Next.Parse(commandPart);
            }

            string path = commandPart.Current;

            return new TreeGotoCommand(path);
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