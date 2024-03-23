using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class FileDeletePath : ParserCommandBase
{
    public override ICommand Parse(IEnumerator<string> commandPart)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (commandPart.MoveNext() && commandPart.Current == "file" && commandPart.MoveNext() && commandPart.Current == "delete")
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
            return new FileDeleteCommand(path);
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