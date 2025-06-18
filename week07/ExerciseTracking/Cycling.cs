namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speedMph;

        public Cycling(DateTime date, int durationMinutes, double speedMph)
            : base(date, durationMinutes)
        {
            _speedMph = speedMph;
        }

        public override double GetDistance()
        {
            // distance = speed * hours
            return _speedMph * (Duration / 60.0);
        }

        public override double GetSpeed() => _speedMph;

        public override double GetPace()
        {
            // pace = minutes per mile
            double dist = GetDistance();
            return Duration / dist;
        }
    }
}
