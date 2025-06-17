using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create shape instances
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        // Display color and area for each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():0.00}");
            Console.WriteLine();
        }
    }
}
