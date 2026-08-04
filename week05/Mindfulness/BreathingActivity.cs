using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Get Ready...");
        ShowSpinner(2);

        int duration = GetDuration();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while(DateTime.Now < endTime)
        {
            Console.Write("Breathe In...");
            ShowCountDown(3);

            if (DateTime.Now >= endTime) 
            {
                break;
            }

            Console.Write("\nNow breathe Out...");
            ShowCountDown(4);

            Console.WriteLine("\n");
        }

        Console.WriteLine("Well Done!");
        ShowSpinner(2);

        DisplayEndingMessage();
        ShowSpinner(2);
    }
}