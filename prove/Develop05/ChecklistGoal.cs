public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _completionsNeeded;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int needed, int completed = 0)
        : base(name, description, points)
    {
        _timesCompleted = completed;
        _completionsNeeded = needed;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;

        if (IsComplete())
            return _points + _bonusPoints;

        return _points;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _completionsNeeded;
    }

    public override string GetStatus()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description}) -- Completed {_timesCompleted}/{_completionsNeeded}";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_completionsNeeded}|{_timesCompleted}";
    }
}