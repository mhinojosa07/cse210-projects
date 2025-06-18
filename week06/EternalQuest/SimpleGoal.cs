namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, int points)
            : base(name, points) { }

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return Points;
            }
            return 0;
        }

        public void MarkCompleted() => _completed = true;

        public override string GetStatus() =>
            $"[{(_completed ? 'X' : ' ')}] {Name}";

        public override string Serialize() =>
            $"Simple|{Name}|{Points}|{_completed}";
    }
}
