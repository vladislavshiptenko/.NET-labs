using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display : IDisplay
{
    private readonly DisplayDriver _driver;
    private string _message;

    public Display(string message, DisplayDriver driver)
    {
        _message = message;
        _driver = driver;
    }

    public void ReceiveMessage(string message)
    {
        _message = message;
    }

    public void PrintMessage(Rgb color)
    {
        _driver.Clear();
        _driver.PrintMessage(_driver.ColoredText(_message, color));
    }
}
