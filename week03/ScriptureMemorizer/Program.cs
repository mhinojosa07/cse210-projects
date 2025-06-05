// Scripture Memorizer Program
// Creative feature: This version loads a library of scriptures from a file called "scriptures.txt"
// and picks a random one to memorize. This helps users practice memorizing different verses each time!

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from a file
        List<Scripture> scriptureLibrary = ScriptureLibrary.LoadFromFile("scriptures.txt");
        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file. Exiting program.");
            return;
        }

        // Pick one scripture at random
        Random rand = new Random();
        Scripture scripture = scriptureLibrary[rand.Next(scriptureLibrary.Count)];

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
