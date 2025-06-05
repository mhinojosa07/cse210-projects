using System.Collections.Generic;
using System.IO;

public static class ScriptureLibrary
{
    // Each line: Book|Chapter|StartVerse|EndVerse(optional)|Text
    // Example: Proverbs|3|5|6|Trust in the Lord with all thine heart and lean not unto thine own understanding
    public static List<Scripture> LoadFromFile(string filename)
    {
        var list = new List<Scripture>();
        if (!File.Exists(filename)) return list;
        foreach (var line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
            var parts = line.Split('|');
            if (parts.Length < 4) continue;
            Reference reference = Reference.Parse($"{parts[0]}|{parts[1]}|{parts[2]}{(string.IsNullOrWhiteSpace(parts[3]) ? "" : "|" + parts[3])}");
            string text = parts.Length > 4 ? parts[4] : "";
            list.Add(new Scripture(reference, text));
        }
        return list;
    }
}
