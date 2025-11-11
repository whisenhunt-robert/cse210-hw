using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void RunActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Timer(3);

        string prompt = GetPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"\n---- {prompt} ----");
        Console.Write("\nYou may begin in: ");
        Countdown(5);
        Console.WriteLine("\nStart listing items. Press enter after each item: \n");

        List<string> items = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input.Trim());
            }

            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        Timer(3);
    }

    private string GetPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}