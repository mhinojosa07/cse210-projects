using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public string Display()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\n";
    }

    public string ToCSV()
    {
        return $"{Date}|{Prompt}|{Response}|{Mood}";
    }

    public static Entry FromCSV(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[1], parts[2], parts[3]) { Date = parts[0] };
    }
}
