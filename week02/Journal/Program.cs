using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        List <string> prompts = ["If I had one thing I could do over today, what would it be? ",
            "What was the best part of your day? ",
            "What was the best meal you ate today? "];

        int option = 0;
        while (option != 5)
        {
            int promptIndex = 0; 
            Console.WriteLine("Please select one of the following choioces: ");
            Console.WriteLine("""
                1. Write
                2. Display
                3. Load
                4. Save
                5. Quit
            """);
            
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                promptIndex = promptIndex + 1;

                Console.Write(prompts[promptIndex]);
                Console.ReadLine();
            }
        }
    }
}