// ListingActivity.cs
using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void PerformActivity()
        {
            var rand = new Random();
            Console.WriteLine("\n\n" + _prompts[rand.Next(_prompts.Count)]);
            Console.WriteLine("\nYou have 5 seconds to think...");
            ShowCountDown(5);

            Console.WriteLine("\nStart listing (one per line). Press Enter on an empty line to finish early.");
            var entries = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter && entries.Count > 0)
                    break;

                string entry = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entry))
                    break;

                entries.Add(entry.Trim());
            }

            Console.WriteLine($"\nYou listed {entries.Count} items.");
        }

        private int GetDuration()
        {
            var field = typeof(Activity)
                        .GetField("_durationSeconds",
                                  System.Reflection.BindingFlags.NonPublic |
                                  System.Reflection.BindingFlags.Instance);
            return (int)field.GetValue(this);
        }
    }
}
