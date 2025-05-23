// Fraction.cs
public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructor: 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor: top/1
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Constructor: top/bottom
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getters and setters
    public int GetNumerator()
    {
        return _numerator;
    }

    public void SetNumerator(int value)
    {
        _numerator = value;
    }

    public int GetDenominator()
    {
        return _denominator;
    }

    public void SetDenominator(int value)
    {
        _denominator = value;
    }

    // Returns the fraction string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Returns the decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
