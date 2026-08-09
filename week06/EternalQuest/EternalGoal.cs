public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations you have earned {getPoints()}");
    }

    public override bool IsComplete()
    {
        return false; 
    }

    public override string GetDetailsString()
    {
        return $"[ ] {getShortName()} ({getDescription()})";
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{getShortName()},{getDescription()},{getPoints()}";
    }
}