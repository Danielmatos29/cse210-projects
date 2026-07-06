using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();

        float grade = float.Parse(userInput);

        char letterResult;

        if (grade >= 90)
        {
            letterResult = 'A';
        }
        else if (grade >= 80)
        {
            letterResult = 'B';
        }
        else if (grade >= 70)
        {
            letterResult = 'C';
        }
        else if (grade >= 60)
        {
            letterResult = 'D';
        }
        else
        {
            letterResult = 'F';
        }

        Console.WriteLine($"Your grade is: {letterResult}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}