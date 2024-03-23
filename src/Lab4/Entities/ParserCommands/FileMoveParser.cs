using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.ParserCommands;

public class FileMoveParser : ParserCommandBase
{
    public override ICommand Parse(IEnumerator<string> commandPart)
    {
        if (commandPart is null)
        {
            throw new ArgumentNullException(nameof(commandPart));
        }

        if (commandPart.MoveNext() && commandPart.Current == "file" && commandPart.MoveNext() && commandPart.Current == "move")
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

            string sourcePath = commandPart.Current;
            if (!commandPart.MoveNext())
            {
                if (Next is null)
                {
                    throw new ParseArgumentException(nameof(commandPart));
                }

                commandPart.Reset();
                return Next.Parse(commandPart);
            }

            string destinationPath = commandPart.Current;
            return new FileMoveCommand(sourcePath, destinationPath);
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