using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplay
{
    public void ReceiveMessage(string message);
    public void PrintMessage(Rgb color);
}