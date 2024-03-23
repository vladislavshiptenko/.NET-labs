using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    public string ColoredText(string message, Rgb color);
    public void PrintMessage(string message);
    public void Clear();
}