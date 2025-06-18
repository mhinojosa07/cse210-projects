namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int durationMinutes, int laps)
            : base(date, durationMinutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // each lap = 50 meters; convert to miles (1 m = 0.000621371 miles)
            double meters = _laps * 50;
            return meters * 0.000621371;
        }

        public override double GetSpeed()
        {
            // mph = distance (miles) / hours
            return GetDistance() / (Duration / 60.0);
        }

        public override double GetPace()
        {
            // minutes per mile
            return Duration / GetDistance();
        }
    }
}
