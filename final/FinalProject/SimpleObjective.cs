using System;

public class SimpleObjective : Objective
{
    private bool _completed;

    public SimpleObjective(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (_completed)
        {
            Console.WriteLine("This goal is already completed!");
            return 0;
        }

        _completed = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override string GetStatus()
    {
        return (_completed ? "[X]" : "[ ] ") + _name + " - " + _description;
    }

    public override string GetSaveString()
    {
        return "SimpleObjective|" + _name + "|" + _description + "|" + _points + "|" + _completed;
    }
}