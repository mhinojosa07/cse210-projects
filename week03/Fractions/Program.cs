// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // Test all constructors
        Fraction f1 = new Fraction();           // 1/1
        Fraction f2 = new Fraction(5);          // 5/1
        Fraction f3 = new Fraction(3, 4);       // 3/4
        Fraction f4 = new Fraction(1, 3);       // 1/3

        // Display outputs
        DisplayFraction(f1);
        DisplayFraction(f2);
        DisplayFraction(f3);
        DisplayFraction(f4);

        // Test setters and getters
        f1.SetNumerator(7);
        f1.SetDenominator(8);
        Console.WriteLine("Updated Fraction f1:");
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
    }

    static void DisplayFraction(Fraction frac)
    {
        Console.WriteLine(frac.GetFractionString());
        Console.WriteLine(frac.GetDecimalValue());
    }
}