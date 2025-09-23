using System;

class Program
{
    static void Main(string[] args)
    {
        // Calls the DisplayWelcome function.
        DisplayWelcome();

        // Calls the PromptUserName function.
        string userName = PromptUserName();
        // Calls the PromptUserNumber function.
        int userNumber = PromptUserNumber();

        // Accepts an integer as a parameter and returns that number squared (as an integer)
        int squaredNumb = SquareNumber(userNumber);

        // Integer variable for birth year of the user.
        int birthYear;
        // Calls the PromptBirthYear fuction.
        PromptBirthYear(out birthYear);
        // Calls the DisplayResult function with user name, squared number, and birth year parameters.
        DisplayResult(userName, squaredNumb, birthYear);
    }

    // Displays the message, "Welcome to the Program!"
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks for and returns the user's name (as a string)
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }
    // Asks for and returns the user's favorite number (as an integer)
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }
    // Accepts out integer parameter and promits the user for the year they were born.
    // The out parameter is set to their birth year. This function does not return a value.
    // The user's given year is given back from the function via the out parameter.
    static void PromptBirthYear(out int birthYear)
    {
        Console.Write($"Please enter the year your were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }
    // Accepts an integer as a parameter and returns that number squared (as an integer).
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    // Accepts the user's name, the squared number, and the user's birth year. Display the user's name and squared number.
    // Calculate how many years old they will turn this year and display that.
    static void DisplayResult(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
        Console.WriteLine($"{name}, you will turn {2025 - birthYear} this year.");
    }
}
    // Welcome to the Program!
    // Please enter your name: Robert Whisenhunt
    // Please enter your favorite number: 42
    // Please enter the year you were born: 1986
    // Brother Whisenhunt, the square of your number is ????
    // Brother Whisenhunt, you will turn 39 this year.