// Activity.cs
using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Template method
        public void Run()
        {
            ShowStartMessage();
            PerformActivity();
            ShowEndMessage();
        }

        // Common starting sequence
        private void ShowStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---\n");
            Console.WriteLine(_description + "\n");
            Console.Write("Enter duration in seconds: ");
            if (!int.TryParse(Console.ReadLine(), out _durationSeconds) || _durationSeconds <= 0)
            {
                Console.WriteLine("Invalid duration. Using 30 seconds.");
                _durationSeconds = 30;
            }
            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
        }

        // Common ending sequence
        private void ShowEndMessage()
        {
            Console.WriteLine("\n\nWell done!");
            ShowSpinner(3);
            Console.WriteLine($"\nYou have completed the {_name} for {_durationSeconds} seconds.");
            Console.WriteLine("\nPress Enter to return to menu.");
            Console.ReadLine();
        }

        // Spinner animation for given seconds
        protected void ShowSpinner(int seconds)
        {
            char[] sequence = { '|', '/', '-', '\\' };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(sequence[i++ % sequence.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        // Countdown animation (prints and erases numbers)
        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Each derived class implements its core logic here
        protected abstract void PerformActivity();
    }
}
