using System;

public class HigherOrLower : Game
{
    private static Random _rand = new Random();
    private int _playerNumber;
    private int _cpuNumber;

    public HigherOrLower(string name, int levelRequired)
        : base(name, levelRequired) { }

    public override int GetTokenCost()
    {
        return 20;
    }

    public override int Play()
    {
        // This randomly generates numbers until both numbers are different.
        do
        {
            _playerNumber = _rand.Next(1, 21);
            _cpuNumber = _rand.Next(1, 21);
        } while (_playerNumber == _cpuNumber);

        Console.WriteLine("\n~ ~ ~ ~ Higher or Lower ~ ~ ~ ~");
        Console.WriteLine("You and the CPU have a randomly generated number.");
        Console.WriteLine("Your task is to predict if your number is higher or lower than the CPU's number.");
        Console.WriteLine("If you predict correctly, you win! Simple as that!");

        Console.Write("\nWill your number be Higher or Lower? (h/l): ");
        string choice = Console.ReadLine().ToLower();

        bool playerIsHigher = _playerNumber > _cpuNumber;
        bool correctGuess =
            (choice == "h" && playerIsHigher) || (choice == "l" && !playerIsHigher);

        Console.WriteLine("\n~ ~ ~ ~ Results ~ ~ ~ ~");
        Console.WriteLine($"Your number is: {_playerNumber}");
        Console.WriteLine($"CPU's number is: {_cpuNumber}");

        if (correctGuess)
        {
            Console.WriteLine("You predicted correctly! Congratulations, you won!");
            return 50;
        }
        else
        {
            Console.WriteLine("I'm sorry, but you guessed wrong. Better luck next time!");
            return 0;
        }
    }

    public override string GetSaveString()
    {
        return "";
    }
}