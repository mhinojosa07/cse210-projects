// Assignment.cs
public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Returns "StudentName - Topic"
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Exposes the student name to derived classes
    public string GetStudentName()
    {
        return _studentName;
    }
}
