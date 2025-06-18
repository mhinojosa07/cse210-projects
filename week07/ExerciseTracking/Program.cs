using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main()
        {
            // Create one of each activity:
            var activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),    // 3 miles in 30 min
                new Cycling(new DateTime(2022, 11, 3), 45, 12.0),   // 12 mph for 45 min
                new Swimming(new DateTime(2022, 11, 3), 60, 20)     // 20 laps (50m each) in 60 min
            };

            // Display their summaries:
            foreach (var act in activities)
            {
                Console.WriteLine(act.GetSummary());
            }
        }
    }
}

