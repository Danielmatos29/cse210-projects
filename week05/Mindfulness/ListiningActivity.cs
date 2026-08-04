public class ListiningActivity : Activity {
    private int _count;
    private List<string> _prompts;

    public ListiningActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>();

        _prompts.Add("Who are people that you appreciate? ");
        _prompts.Add("What are personal strengths of yours? ");
        _prompts.Add("Who are people that you have helped this week? ");
        _prompts.Add("When have you felt the Holy Ghost this month? ");
        _prompts.Add("Who are some of your personal heroes? ");
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Get Ready...");
        ShowSpinner(2);

        GetRandomPrompt();

        List<string> userItems = GetListFromUser();
        
        Console.WriteLine("Well done!\n");
        _count = userItems.Count;
        Console.WriteLine($"\nYou listed {_count} items!");
        ShowSpinner(2);

        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random number = new Random();

        int randomNum = number.Next(_prompts.Count);

        Console.WriteLine(_prompts[randomNum]);
    }

    public List<string> GetListFromUser()
    {
       List<string> userItems = new List<string>();
        Console.WriteLine("List as many items as you can. Press Enter on an empty line when finished:\n");

        int duration = GetDuration();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            userItems.Add(input);
        };
       return userItems;
    }
}