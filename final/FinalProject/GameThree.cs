using System;
using System.ComponentModel;
using System.Threading;

public class GameThree : Game
{
    private static Random _rand = new Random();
    private char[] _symbols = { '@', '%', '$' };
    private char[] _results = new char[3];

    public GameThree(string name, int levelRequired)
        : base(name, levelRequired) { }

    public override int GetTokenCost()
    {
        return 30;
    }

    public override int Play()
    {
        Console.WriteLine("\n~ ~ ~ ~ ~ Treasure Box ~ ~ ~ ~");
        Console.WriteLine("Press ENTER to hit the Treasure Box!");
        Console.WriteLine("Match three of the same symbol to win!");

        if (Console.BufferWidth < 6)
        {
            Console.WriteLine("Please widen the console window in order to play this game.");
            return 0;
        }

        // Sets the starting column to the first box.
        int _startBox = Console.CursorLeft;
        // Sets the row to display all boxes.
        int _row = Console.CursorTop;

        for (int i = 0; i < 3; i++)
        {
            char current = ' ';
            bool stopped = false;

            while (!stopped)
            {
                current = _symbols[_rand.Next(_symbols.Length)];

                int box = Math.Min(_startBox + i * 2, Console.BufferWidth - 1);
                int displayRow = Math.Min(_row, Console.BufferHeight - 1);

                Console.SetCursorPosition(box, displayRow);
                Console.Write(current);
                Thread.Sleep(200);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        stopped = true;
                }
            }

            _results[i] = current;
        }

        int resultRow = Math.Min(_row + 2, Console.BufferHeight - 1);
        Console.SetCursorPosition(0, resultRow);

        Console.WriteLine("\n~ ~ ~ ~ Results ~ ~ ~ ~");
        Console.WriteLine(_results[0] + " " + _results[1] + " " + _results[2]);

        if (_results[0] == _results[1] && _results[1] == _results[2])
        {
            int exp = GetReward(_results[0]);
            Console.WriteLine($"Congratulations! You won!");
            return exp;
        }

        Console.WriteLine("These symbols don't match. Better luck next time!");
        return 0;
    }

    private int GetReward(char symbol)
    {
        if (symbol == '@')
            return 25;

        if (symbol == '%')
            return 50;

        if (symbol == '$')
            return 100;

        return 0;
    }

    public override string GetSaveString()
    {
        return "";
    }
}