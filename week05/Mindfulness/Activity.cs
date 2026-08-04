using System.Security.Cryptography.X509Certificates;

public class Activity
{
    protected string _name = "";
    protected string _description = "";
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int SetDuration(int duration)
    {
        return _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine("\nWelcome to the " + _name + " activity");

        Console.WriteLine("\n" + _description);

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        SetDuration(int.Parse(Console.ReadLine()));
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nYou have completed " + _duration + " seconds of " + _name + " activity");
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>();
        spinner.Add("\\");
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");
        spinner.Add("\\");
        spinner.Add("|");
        spinner.Add("/");
        spinner.Add("-");

        foreach (string s in spinner)
        {
            for (int i = 0; i <= seconds; i++)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    } 

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second

            // Multi-digit numbers (like 10) need as many backspaces as they have digits
            int numberLength = i.ToString().Length;
            for (int b = 0; b < numberLength; b++)
            {
                Console.Write("\b \b"); // Erase character from terminal
            }
        }
    }
}