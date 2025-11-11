using System;
using System.Threading;

public class GuessingActivity : Activity
{
    private int _secretNumber;

    public GuessingActivity(string name, string description)
        : base(name, description)
    {
    }

    public void RunActivity()
    {
        Console.Clear();
        Random rand = new Random();
        // Sets the secret number to a random number between 1 and 100.
        _secretNumber = rand.Next(1, 101);

        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        Console.WriteLine("Try to guess it before the timer runs out!");
        Timer(3);
        Console.WriteLine("Get ready...");
        Timer(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        bool correctGuess = false;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Please enter your guess: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int guess))
            {
                if (guess == _secretNumber)
                {
                    correctGuess = true;
                    break;
                }
                else if (guess < _secretNumber)
                {
                    Console.WriteLine("Higher!");
                }
                else
                {
                    Console.WriteLine("Lower!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number between 1 and 100.");
            }
        }

        if (correctGuess)
        {
            Console.WriteLine("You guessed the secret number!\n");
            Timer(3);
        }
        else
        {
            Console.WriteLine("\nTime's up! I'm sorry, but you didn't guess the number in time!");
            Timer(3);
            Console.WriteLine($"The correct number was: {_secretNumber}!");
            Timer(3);
            Console.WriteLine("\nIt's the effort that matters though right? You're still a winner for trying!");
            Timer(3);
        }
    }
}