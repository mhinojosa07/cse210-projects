// Bonus: This implementation is structured for easy expansion to load multiple scriptures from file
// or randomly select one at runtime. Classes use encapsulation and are for future features such as hint mode,
// verse library support, or timed memorization challenges.

using System;

class Program
{
    static void Main(string[] args)
    {
        // Example Scripture (stretch: you could load multiple from a file)
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }
}
