using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GitlabProject;

public partial class LineElements
{
    private const string CorrectLine = @"^(\d+(\.\d+)?,)*\d+(\.\d+)?$";
    private readonly Dictionary<int, decimal> _correctLines = [];
    private readonly List<string> _brokenLines = [];

    public void VerifyAndSum(string[] lines)
    {
        var regex = MyRegex();
        _correctLines.Clear();
        _brokenLines.Clear();

        for (var i = 0; i < lines.Length; i++)
        {
            if (regex.IsMatch(lines[i]))
                _correctLines.Add(i+1, Sum(lines[i]));
            
            if (!regex.IsMatch(lines[i]))
                _brokenLines.Add(lines[i]);
        }

        Check();
    }

    public int GetMax() => _correctLines.Aggregate((maxEntry, currentEntry) => 
        currentEntry.Value > maxEntry.Value ? currentEntry : maxEntry).Key;

    public int GetMin() => _correctLines.Aggregate((minEntry, currentEntry) => 
        currentEntry.Value < minEntry.Value ? currentEntry : minEntry).Key;
    
    private static decimal Sum(string line)
    {
        return line.Split(',').Select(decimal.Parse).Sum();
    }

    private void Check()
    {
        if (_correctLines.Count != 0) return;
        
        if (_brokenLines.Count == 0)
            throw new ArgumentException("No lines found");
        
        throw new ArgumentException("No correct lines found");
    }

    [GeneratedRegex(CorrectLine)]
    private static partial Regex MyRegex();
}