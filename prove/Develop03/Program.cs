using System;

class Program
{
    static void Main(string[] args)
    {
        // I tried to include this in the Reference class, but had some issues with is; so I hope it's okay to have this here?
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";

        // Gets the difficulty level from the user as part of my exceeding expectations.
        int difficulty = GetDifficultyLevel();

        Scripture scripture = new Scripture(text, reference, difficulty);

        while (true)
        {
            Console.Clear();
            scripture.DisplayScripture();

            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
                break;

            scripture.HideWords();

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                scripture.DisplayScripture(showReference: false);
                Console.WriteLine();
                // Added this line to let the user know that the program ends since all words are hidden.
                Console.WriteLine("All words are hidden. The program will now end.");
                break;
            }
        }
    }
    
    // Used this to exceed expectations. Prompting the user to choose how many words will be hidden.
    // Found examples on stackoverflow on how to make this possible.
    private static int GetDifficultyLevel()
    {
        int level = 0;

        while (true)
        {
            // Prompts the user to enter a number between 1 and 5 to decide how many words are hidden.
            Console.Write("Please choose how many words you wish to hide (1-5): ");
            // Stores the user's input into the input string.
            string input = Console.ReadLine();

            if (int.TryParse(input, out level) && level >= 1 && level <= 5)
            {
                // Let's the user know their number was entered successfully.
                Console.WriteLine($"\nEach time you press Enter, {level} words will be hidden.\n");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.\n");
            }
        }
        return level;
    }
}