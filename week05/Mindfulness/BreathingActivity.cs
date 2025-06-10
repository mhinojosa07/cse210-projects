// BreathingActivity.cs
using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
            while (DateTime.Now < endTime)
            {
                Console.Write("\n\nBreathe in... ");
                ShowCountDown(4);
                Console.Write("\nBreathe out... ");
                ShowCountDown(6);
            }
        }

        // Expose durationSeconds from base via reflection on private field
        // (Or change base to protected property if you prefer)
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
