using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _durationMinutes;

        protected Activity(DateTime date, int durationMinutes)
        {
            _date = date;
            _durationMinutes = durationMinutes;
        }

        public DateTime Date => _date;
        public int Duration => _durationMinutes;

        // Must be overridden by derived classes:
        public abstract double GetDistance();    // in miles
        public abstract double GetSpeed();       // in mph
        public abstract double GetPace();        // in min per mile

        // Virtual summary that uses the three methods above:
        public virtual string GetSummary()
        {
            string dateStr = _date.ToString("dd MMM yyyy");
            double dist = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();

            return $"{dateStr} {GetType().Name} ({_durationMinutes} min) - " +
                   $"Distance {dist:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
        }
    }
}
