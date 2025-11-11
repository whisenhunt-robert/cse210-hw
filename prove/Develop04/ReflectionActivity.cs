using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficulty.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this expereince meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string name, string description)
        : base(name, description)
    {
    }

    public void RunActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Timer(3);

        string prompt = GetPrompt();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" ---- {prompt} ---- ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetQuestion();
            Console.Write($"> {question} ");
            Spinner(10);
            Console.WriteLine();
        }
    }

    private string GetPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    private void Spinner(int seconds)
    {
        string[] spinnerFrames = { "/", "-", "\\", "|" };
        int frameIndex = 0;
        DateTime start = DateTime.Now;
        
        while ((DateTime.Now - start).TotalSeconds < seconds)
        {
            Console.Write(spinnerFrames[frameIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % spinnerFrames.Length;
        }
    }
}