using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompts the user to enter the magic number.
        // Console.Write("What is the magic number? ");
        // int magicNumb = int.Parse(Console.ReadLine());

        // Welcome message for the user.
        Console.WriteLine("Welcome to the Number Guessing Game! Guess the number between 1 - 100 to win!");

        // Creates the random number generator.
        Random randomGenerator = new Random();
        // Randomly generates a number integer between 1 and 100.
        int magicNumb = randomGenerator.Next(1, 100);

        // Integer variable for guessing the number.
        int guess = 0;
        // Integer variable for keeping score.
        int score = 0;
        // String variable to set the default response to "yes".
        string response = "yes";

        // While loop that runs the game itself.
        while (response == "yes")
        {
            // Prompts the user to enter a number they wish to guess.
            Console.Write("What is your guess? ");
            // Returns the user's guess and updates the variable to the number they entered.
            guess = int.Parse(Console.ReadLine());

            // If statement to let the user know the randomly generated number is higher than what they entered.
            if (guess < magicNumb)
            {
                Console.Write("Higher\n");
            }
            // Else if statement to let the user know the randomly generated number is lower than what they entered.
            else if (guess > magicNumb)
            {
                Console.Write("Lower\n");
            }
            // Else statement for when the user guesses the randomly generated number correctly.
            else
            {
                Console.WriteLine("You guessed it!");
                // Adds one point to the total score.
                score++;
                // Prints the score of how many currect guesses the user has gotten.
                Console.WriteLine($"Your score is {score}!");
                // Creates a new randomly generated number incase the user wants to play again.
                magicNumb = randomGenerator.Next(1, 100);
                // Prompts the user to say yes if they wish to play again.
                Console.Write("Do you want to play again? ");
                // Returns the user's answer and updates the response variable.
                response = Console.ReadLine();
            }
        }
    }
}