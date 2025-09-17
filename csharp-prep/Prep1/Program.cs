using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompts the user to input their first name.
        Console.Write("What is your first name? ");
        // Returns the user's first name into a string variable from what they typed in.
        string firstName = Console.ReadLine();

        // Prompts the user to input their first name.
        Console.Write("What is your last name? ");
        // Returns the user's last name into a string variable from what they typed in.
        string lastName = Console.ReadLine();

        // Uses variables inside a string to print the user's name, James Bond style.
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}