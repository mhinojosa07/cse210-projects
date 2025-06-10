// MathAssignment.cs
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }

    // Returns "Section 7.3 Problems 3-10, 20-21"
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
