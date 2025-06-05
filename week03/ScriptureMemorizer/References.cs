public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    // Single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    // Verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}";
    }

    // For file loading: expects "Book|Chapter|StartVerse|EndVerse(optional)"
    public static Reference Parse(string line)
    {
        // Format: Book|Chapter|StartVerse|EndVerse
        string[] parts = line.Split('|');
        string book = parts[0];
        int chapter = int.Parse(parts[1]);
        int startVerse = int.Parse(parts[2]);
        if (parts.Length == 4 && !string.IsNullOrEmpty(parts[3]))
        {
            int endVerse = int.Parse(parts[3]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            return new Reference(book, chapter, startVerse);
        }
    }
}
