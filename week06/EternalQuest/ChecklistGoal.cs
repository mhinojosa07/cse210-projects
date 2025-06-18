namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _progress;
        private int _target;
        private int _bonus;
        private bool _completed;

        public ChecklistGoal(string name, int points, int target, int bonus)
            : base(name, points)
        {
            _target = target;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (_completed) return 0;

            _progress++;
            if (_progress < _target)
                return Points;

            _completed = true;
            return Points + _bonus;
        }

        public void SetProgress(int p)
        {
            _progress = p;
            if (p >= _target) _completed = true;
        }

        public override string GetStatus() =>
            _completed
                ? $"[X] {Name} ({_progress}/{_target})"
                : $"[ ] {Name} ({_progress}/{_target})";

        public override string Serialize() =>
            $"Checklist|{Name}|{Points}|{_target}|{_bonus}|{_progress}";
    }
}
