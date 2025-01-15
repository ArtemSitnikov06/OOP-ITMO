using Itmo.ObjectOrientedProgramming.Lab3.DisplayEntity;
using Itmo.ObjectOrientedProgramming.Lab3.FileWritee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adapters;

public class FileOutputAdapter : IDisplay
{
    private readonly FileWriter _fileWriter;

    public FileOutputAdapter(FileWriter fileWriter)
    {
        _fileWriter = fileWriter;
    }

    public void ShowMessage(string message)
    {
        _fileWriter.WriteToFile(message);
    }
}