// Improve the process of saving and loading to save as a .csv file that could be opened in Excel (make sure to account for quotation marks and commas correctly in your content.
using System;
class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator prompt = new PromptGenerator();

        int option = 0;

        while (option != 5)
        {
            Console.WriteLine("Please select one of the following choices: ");

            Console.WriteLine("""
            1. Write
            2. Display
            3. Load
            4. Save
            5. Quit
            What would you like to do? 
            """);

            option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Entry myEntry = new Entry();

                myEntry._promptText = prompt.GetRandomPrompt();
                Console.WriteLine(myEntry._promptText);
                
                myEntry._entryText = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;

                myEntry._date = theCurrentTime.ToShortDateString();
                myJournal._entries.Add(myEntry);
            }
            else if (option == 2)
            {
                myJournal.DisplayAll();
            }
            else if (option == 3)
            {
                Console.WriteLine("What is the file name? ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (option == 4)
            {
                Console.WriteLine("What is the file name? ");
                string filename = Console.ReadLine();

                myJournal.SaveToFile(filename);
            }
        }
    }
}