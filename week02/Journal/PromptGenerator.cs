using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompt = new List<string>();

    public string GetRandomPrompt()
    {
        _prompt.Add("What was the quietest moment of your day so far?");
        _prompt.Add("What feelings did you experiences today and why? ");
        _prompt.Add("What is a small habit that completely changed how you manage your time? ");
        _prompt.Add("If you had to describe your current mood using only a color and a weather condition, what would it be? ");

        Random rand = new Random();

        int number = rand.Next(0, _prompt.Count);

        return _prompt[number];
    }
}