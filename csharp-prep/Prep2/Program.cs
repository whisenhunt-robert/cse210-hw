using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompts the user to input a number percentage. Does not work with decimals (yet).
        Console.Write("Please enter your grade percentage: ");
        // Returns the user's first name into a string variable from what they typed in.
        string userInput = Console.ReadLine();
        // Converts the value of the userInput variable from a string to an interger.
        int grade = int.Parse(userInput);
        // Creates the letter variable.
        string letter = "";

        // if and else if statements to determine the letter grade based off the user's input.
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Prints the letter grade that was determined by the statements above.
        Console.WriteLine($"Your grade is: {letter}");

        // if and else statement to determine if the grade is a passing grade or not.
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You've passed the class!");
        }
        else
        {
            Console.WriteLine("I'm sorry, but that isn't a passing grade.");
        }
    }
}