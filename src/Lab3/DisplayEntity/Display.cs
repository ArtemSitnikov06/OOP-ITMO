namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntity;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;

    private readonly ConsoleColor _color;

    public Display(IDisplayDriver driver, ConsoleColor color)
    {
        _driver = driver;
        _color = color;
    }

    public void ShowMessage(string message)
    {
        _driver.Clear();
        _driver.SetColor(_color);
        _driver.WriteText(message);
    }
}