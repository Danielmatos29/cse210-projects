using System.Runtime;
using System.Runtime.InteropServices;

public class CheckList : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckList(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    } 

    public int getTarget()
    {
        return _target;
    }

    public void setBonus(int bonus)
    {
        _bonus = bonus;
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
    public int getBonus()
    {
        return _bonus;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }

        return false;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;

        Console.WriteLine($"Congratulations you have earned {getPoints()}");
    }

    public override string GetDetailsString()
    {
        string completionCheck = "[ ]";
        if (IsComplete() == true)
        {
            completionCheck = "[X]";
            return $"{completionCheck} {getShortName()} ({getDescription()}) -- Currently completed {_amountCompleted}/{getTarget()}";
        }
        
        return $"{completionCheck} {getShortName()} ({getDescription()}) -- Currently completed {_amountCompleted}/{getTarget()}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{getShortName()},{getDescription()},{getPoints()},{_bonus},{_amountCompleted},{_target}";
    }
}