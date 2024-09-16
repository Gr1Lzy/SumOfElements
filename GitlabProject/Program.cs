using System;

namespace GitlabProject;

internal static class Program
{
    public static void Main(string?[] args)
    {
        var lineElements = new LineElements();
        lineElements.VerifyAndSum(FileReader.Read("../../../../GitlabProject/textFile.txt"));
        
        Console.WriteLine("Max: " + lineElements.GetMax() + " index");
            
        Console.WriteLine("Min: " + lineElements.GetMin() + " index");
    }
}