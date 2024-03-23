using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string logText)
    {
        Console.WriteLine(logText);
    }
}