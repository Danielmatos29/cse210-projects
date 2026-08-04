public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."){
        _prompts = new List<string>();
        _questions = new List<string>();

        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }   

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Get Ready...");
        ShowSpinner(2);

        int duration = GetDuration();
        
        Console.WriteLine("Consider the following prompt: \n");

        DisplayPrompt();

        Console.Write("\nWhen you have something in mind, press enter to continue: ");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experinece");

        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        List<string> unusedQuestions = new List<string>(_questions);
        Random rand = new Random();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {

            if (unusedQuestions.Count == 0)
            {
                unusedQuestions = new List<string>(_questions);
            }

            int index = rand.Next(unusedQuestions.Count);
            
            Console.Write("\n> ");
            Console.WriteLine(unusedQuestions[index]);

            unusedQuestions.RemoveAt(index);

            ShowSpinner(8);
        }
        
        Console.WriteLine("Well Done!");
        ShowSpinner(2);

        DisplayEndingMessage();
        ShowSpinner(2);
    }

    public string GetRandomPrompt()
    {
        Random number = new Random();

        int randomNum = number.Next(_prompts.Count);

        return _prompts[randomNum];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("--- " + GetRandomPrompt() + " ---");
    }
}