using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        // Make the list
        List<int> numbers = new List<int>();

        bool loopBreaker = false;

        // Ask the user for a number to append to the list
        while (loopBreaker == false)
        {
            Console.Write("Enter a number: ");

            int number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
            else
            {
                loopBreaker = true;
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum of the numbers is {sum}");

        float avarageNumber = ((float)sum) / numbers.Count;

        Console.WriteLine($"The avarage of numbers is {avarageNumber}");

        int max = 0;

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max of numbers is {max}");
    }
}