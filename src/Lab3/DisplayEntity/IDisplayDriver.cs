namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntity;

public interface IDisplayDriver
{
    void Clear();

    void SetColor(ConsoleColor color);

    void WriteText(string text);
}