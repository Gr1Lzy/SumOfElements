using System.IO;

namespace GitlabProject;

public static class FileReader
{
    public static string[] Read(string? path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("File not found", path);
        return File.ReadAllLines(path);
    }
}