using System;
using System.Threading;
using System.Collections.Generic;

public class GameFour : Game
{
    private static Random _rand = new Random();

    public GameFour(string name, int levelRequired)
        : base(name, levelRequired) { }

    public override int GetTokenCost()
    {
        return 25;
    }

    public override int Play()
    {
        Console.WriteLine("~ ~ ~ ~ Blackjack ~ ~ ~ ~");
        Console.WriteLine("Try to get as close to 21 without going over");

        List<int> _playerHand = new List<int>();
        List<int> _dealerHand = new List<int>();

        DealCard(_playerHand);
        DealCard(_playerHand);
        DealCard(_dealerHand);
        DealCard(_dealerHand);

        bool _playerBust = false;

        // Player's turn
        while (true)
        {
            int _playerNumber = CalculateTotal(_playerHand);
            Console.WriteLine("\nPlayer's Hand: " + FormatHand(_playerHand) + " (" + _playerNumber + ")");
            Console.Write("Do you wish to Hit (h) or Stand (s)? ");

            string choice = Console.ReadLine().ToLower();
            if (choice == "h")
            {
                DealCard(_playerHand);
                _playerNumber = CalculateTotal(_playerHand);
                if (_playerNumber > 21)
                {
                    Console.WriteLine("\nPlayer's Hand: " + FormatHand(_playerHand) + " (" + _playerNumber + ")");
                    Console.WriteLine("\nI'm sorry, but that's a bust!");
                    _playerBust = true;
                    break;
                }
            }
            else if (choice == "s")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        // Dealer's turn (if the player didn't bust)
        int _dealerNumber = CalculateTotal(_dealerHand);
        if (!_playerBust)
        {
            while (_dealerNumber < 17)
            {
                DealCard(_dealerHand);
                _dealerNumber = CalculateTotal(_dealerHand);
            }
            Console.WriteLine("\nDealer's Hand: " + FormatHand(_dealerHand) + " (" + _dealerNumber + ")");
            Thread.Sleep(2000);
        }

        int _playerFinal = CalculateTotal(_playerHand);
        int _dealerFinal = CalculateTotal(_dealerHand);

        if (_playerBust || (_dealerFinal <= 21 && _dealerFinal >= _playerFinal))
        {
            Console.WriteLine("\nDealer wins. Better luck next time!");
            return 0;
        }

        Console.WriteLine("\nCongratulations! You won!");
        int exp = 50;
        return exp;
    }

    private void DealCard(List<int> hand)
    {
        int card = _rand.Next(1, 12);
        hand.Add(card);
    }

    private int CalculateTotal(List<int> hand)
    {
        int total = 0;
        int aces = 0;

        foreach (int card in hand)
        {
            total += card;
            if (card == 11)
                aces++;
        }

        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }

        return total;
    }

    private string FormatHand(List<int> hand)
    {
        string result = "";
        for (int i = 0; i < hand.Count; i++)
        {
            result += hand[i];
            if (i < hand.Count - 1)
                result += ", ";
        }
        return result;
    }

    public override string GetSaveString()
    {
        return "";
    }
}