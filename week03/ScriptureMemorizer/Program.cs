using System;
using System.Net;
using System.Reflection.Metadata;

class Program
{

    static void Main(string[] args)
    {
        Reference myFavScripture = new Reference("Matthew", 17, 20);
        string text = "And Jesus said unto them, Because of your unbelief: for verily I say unto you, If ye have faith as a grain of mustard seed, ye shall say unto this mountain. Remove hence to yonder place; and it shall remove; and nothing shall be impossible unto you";
        Scripture scripture = new Scripture(myFavScripture, text);

        string input = "";
        while (input.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type \'quit\' to finish");

            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                if (scripture.IsCompletelyHidden())
                {
                    break;
                }
                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress enter to continue or type \'quit\' to finish");
            }
        }
    }
}