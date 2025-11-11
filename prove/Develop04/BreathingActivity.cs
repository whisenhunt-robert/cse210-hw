using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void RunActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Timer(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            Countdown(4);
            Console.WriteLine();

            Console.Write("Now breathe out... ");
            Countdown(6);
            Console.WriteLine("\n");
        }
    }
}