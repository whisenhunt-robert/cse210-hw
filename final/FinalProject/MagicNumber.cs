using System;

public class MagicNumber : Game
{
    private static Random _rand = new Random();
    private int _magicNumber;
    private int _attempts;

    public MagicNumber(string name, int levelRequired)
        : base(name, levelRequired) { }

    public override int Play()
    {
        _magicNumber = _rand.Next(1, 100);
        _attempts = 0;

        Console.WriteLine("\n~ ~ ~ ~ Welcome to Magic Number ~ ~ ~ ~");
        Console.WriteLine("Try to guess the Magic Number within' 20 attempts.");
        Console.WriteLine("The Magic Number is between 1 and 100.");

        while (_attempts < 20)
        {
            Console.WriteLine("Please enter a number between 1 and 100: ");

            int guess;
            if (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            _attempts++;

            if (guess == _magicNumber)
            {
                Console.WriteLine("That's it! You correctly guessed the Magic Number!");
                return EvaluateAttempts(_attempts);
            }

            Console.WriteLine(guess < _magicNumber ? "Higher!" : "Lower!");
        }

        Console.WriteLine("\nYou failed to guess the number within' your 20 attempts...");
        Console.WriteLine($"The Magic Number was {_magicNumber}! Please try again!");
        return 0;
    }

    private int EvaluateAttempts(int attempts)
    {
        if (attempts < 5) return 100;
        if (attempts <= 10) return 50;
        return 25;
    }

    public override string GetSaveString()
    {
        return "";
    }
}