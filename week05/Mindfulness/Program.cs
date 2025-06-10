// Program.cs
using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program\n");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        new BreathingActivity().Run();
                        break;
                    case "2":
                        new ReflectionActivity().Run();
                        break;
                    case "3":
                        new ListingActivity().Run();
                        break;
                    case "4":
                        Console.WriteLine("\nGoodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
