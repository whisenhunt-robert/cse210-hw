using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session?: ");
        _duration = int.Parse(Console.ReadLine() ?? "00");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        Timer(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}");
        Timer(3);
        Console.Clear();
    }

    public void Timer(int seconds)
    {
        string[] spinnerFrames = { "|", "/", "-", "\\", };
        int frameIndex = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerFrames[frameIndex]);
            Thread.Sleep(300);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % spinnerFrames.Length;
        }
    }
    
    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}