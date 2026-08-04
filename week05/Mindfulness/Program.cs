/*
 * EXCEEDING REQUIREMENTS:
 * In ReflectionActivity.cs, implemented a dynamic list copy (unusedQuestions) 
 * to track shown questions. This ensures no question repeats during a session 
 * until every question in the list has been displayed at least once.
 */

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int userInput = 0;

        // Loop runs until the user selects 4 (Quit)
        while (userInput != 4)
        {
            Console.Clear(); // Clears the console so the menu always looks fresh
            
            Console.WriteLine("""
            Menu Options:
                1. Start Breathing Activity
                2. Start Reflection Activity
                3. Start Listing Activity
                4. Quit
            """);

            Console.Write("Select choice from menu: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out userInput))
            {
                switch (userInput)
                {
                    case 1:
                        BreathingActivity breathingSession = new BreathingActivity();
                        breathingSession.Run();
                        break;
                    case 2:
                        ReflectionActivity reflectionSession = new ReflectionActivity();
                        reflectionSession.Run();
                        break;
                    case 3:
                        // Note: Match this to exactly how you spelled it in your class! 
                        ListiningActivity listingSession = new ListiningActivity();
                        listingSession.Run();
                        break;
                    case 4:
                        Console.WriteLine("Great job today! Goodbye.");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number (1-4).");
                        Thread.Sleep(1000);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please type a number.");
                Thread.Sleep(1000);
            }
        }
    }
}