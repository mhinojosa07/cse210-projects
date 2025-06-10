// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Test the base Assignment class
        var simple = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(simple.GetSummary());
        // Output: Samuel Bennett - Multiplication

        Console.WriteLine();

        // 2. Test MathAssignment
        var math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        // Output:
        // Roberto Rodriguez - Fractions
        // Section 7.3 Problems 8-19

        Console.WriteLine();

        // 3. Test WritingAssignment
        var writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
        // Output:
        // Mary Waters - European History
        // The Causes of World War II by Mary Waters
    }
}
