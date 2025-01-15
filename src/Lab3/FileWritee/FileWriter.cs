namespace Itmo.ObjectOrientedProgramming.Lab3.FileWritee;

public class FileWriter : IFileWriter
{
    private readonly string _filePath;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteToFile(string content)
    {
        File.AppendAllText(_filePath, content);
    }
}