using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class DisplayDriver : IDisplayDriver
{
    public string ColoredText(string message, Rgb color)
    {
        if (color is null)
        {
            throw new ArgumentNullException(nameof(color));
        }

        return Crayon.Output.Rgb(color.Red, color.Green, color.Blue).Text(message);
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Clear()
    {
        Console.Clear();
    }
}