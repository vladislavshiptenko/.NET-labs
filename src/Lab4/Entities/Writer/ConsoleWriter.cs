using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Writer;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}