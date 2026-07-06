using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        
        int number = randomGenerator.Next(1, 101);

        int numberSelection;

        do
        {
            Console.Write("What is your number? ");
            numberSelection = int.Parse(Console.ReadLine());

            if (numberSelection > number)
            {
                Console.WriteLine("Lower");
            }
            else if (numberSelection < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        } while (numberSelection != number);
    }   
}