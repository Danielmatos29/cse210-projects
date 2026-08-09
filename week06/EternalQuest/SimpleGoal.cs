using System.Drawing;
using System.Net.Http.Headers;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        
    }

    public void setChecking(bool checkComplete)
    {
        _isComplete = checkComplete;
    }

    public override void RecordEvent()
    {
        if (_isComplete == true)
        {
            Console.WriteLine($"Congratulations you have earned {getPoints()}");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string completionCheck = "[ ]";
        if (IsComplete() == true)
        {
            completionCheck = "[X]";
            return $"{completionCheck} {getShortName()} ({getDescription()})";
        }
        
        return $"{completionCheck} {getShortName()} ({getDescription()})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{getShortName()},{getDescription()},{getPoints()},{IsComplete()}";
    }
}