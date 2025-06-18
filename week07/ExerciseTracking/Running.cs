namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distanceMiles;

        public Running(DateTime date, int durationMinutes, double distanceMiles)
            : base(date, durationMinutes)
        {
            _distanceMiles = distanceMiles;
        }

        public override double GetDistance() => _distanceMiles;

        public override double GetSpeed()
        {
            // speed = distance / hours
            return _distanceMiles / (Duration / 60.0);
        }

        public override double GetPace()
        {
            // pace = minutes per mile
            return Duration / _distanceMiles;
        }
    }
}
