using System;

namespace EternalQuest
{
    abstract class Goal
    {
        public string Name { get; protected set; }
        public int Points { get; protected set; }

        protected Goal(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public abstract int RecordEvent();
        public abstract string GetStatus();
        public abstract string Serialize();

        public static Goal Deserialize(string line)
        {
            var parts = line.Split('|');
            var type = parts[0];
            var name = parts[1];
            var pts = int.Parse(parts[2]);

            switch (type)
            {
                case "Simple":
                    bool completed = bool.Parse(parts[3]);
                    var gSimple = new SimpleGoal(name, pts);
                    if (completed) gSimple.MarkCompleted();
                    return gSimple;

                case "Eternal":
                    return new EternalGoal(name, pts);

                case "Checklist":
                    int target = int.Parse(parts[3]);
                    int bonus = int.Parse(parts[4]);
                    int progress = int.Parse(parts[5]);
                    var gCheck = new ChecklistGoal(name, pts, target, bonus);
                    gCheck.SetProgress(progress);
                    return gCheck;

                default:
                    throw new Exception($"Unknown goal type '{type}'");
            }
        }
    }
}
