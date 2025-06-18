using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        const string SAVE_FILE = "goals.txt";
        static List<Goal> _goals = new List<Goal>();
        static int _score = 0;

        static void Main()
        {
            LoadGoals();

            while (true)
            {
                Console.WriteLine("\nEternal Quest Menu");
                Console.WriteLine("1. Show goals and score");
                Console.WriteLine("2. Create new goal");
                Console.WriteLine("3. Record an event");
                Console.WriteLine("4. Save goals");
                Console.WriteLine("5. Load goals");
                Console.WriteLine("6. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowStatus();
                        break;
                    case "2":
                        CreateGoal();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        SaveOnExit();
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ShowStatus()
        {
            Console.WriteLine($"\nYour score: {_score}\n");
            if (_goals.Count == 0)
            {
                Console.WriteLine("  (no goals yet)");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("\nSelect goal type:");
            Console.WriteLine("1. Simple");
            Console.WriteLine("2. Eternal");
            Console.WriteLine("3. Checklist");
            Console.Write("Choice: ");
            var type = Console.ReadLine();

            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Base points: ");
            if (!int.TryParse(Console.ReadLine(), out int pts))
            {
                Console.WriteLine("Invalid number—aborting.");
                return;
            }

            switch (type)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, pts));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, pts));
                    break;
                case "3":
                    Console.Write("Target count: ");
                    if (!int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.WriteLine("Invalid number—aborting.");
                        return;
                    }
                    Console.Write("Bonus on completion: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid number—aborting.");
                        return;
                    }
                    _goals.Add(new ChecklistGoal(name, pts, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    return;
            }

            Console.WriteLine("Goal created!");
        }

        static void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            ShowStatus();
            Console.Write("\nWhich goal did you complete? (number) ");
            if (int.TryParse(Console.ReadLine(), out int idx)
                && idx >= 1 && idx <= _goals.Count)
            {
                var goal = _goals[idx - 1];
                int earned = goal.RecordEvent();
                _score += earned;

                Console.WriteLine(earned > 0
                    ? $"You earned {earned} points!"
                    : "No points earned (maybe it's already complete).");
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void SaveGoals()
        {
            using var writer = new StreamWriter(SAVE_FILE);
            writer.WriteLine(_score);
            foreach (var g in _goals)
                writer.WriteLine(g.Serialize());
            Console.WriteLine("Goals saved.");
        }

        static void LoadGoals()
        {
            _goals.Clear();
            if (!File.Exists(SAVE_FILE)) return;

            var lines = File.ReadAllLines(SAVE_FILE);
            if (lines.Length == 0) return;

            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
                _goals.Add(Goal.Deserialize(lines[i]));

            Console.WriteLine("Goals loaded.");
        }

        static void SaveOnExit()
        {
            Console.Write("Save before quitting? (Y/N): ");
            var ans = Console.ReadLine().Trim().ToUpper();
            if (ans == "Y")
                SaveGoals();
            Console.WriteLine("Goodbye!");
        }
    }
}
