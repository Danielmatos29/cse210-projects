using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Daniel Matos", "Multiplication");
        Console.WriteLine(a1.GetSummary() + "\n");

        MathAssignment math1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        
        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList() + "\n");

        WritingAssignment writing1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(writing1.GetSummary());
        Console.WriteLine(writing1.GetWritingInformation());
    }
}