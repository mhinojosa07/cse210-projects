// WritingAssignment.cs
public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Returns "The Causes of World War II by Mary Waters"
    public string GetWritingInformation()
    {
        // Use the base-class getter to retrieve the private _studentName
        return $"{_title} by {GetStudentName()}";
    }
}
