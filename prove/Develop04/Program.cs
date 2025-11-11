using System;

public class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            DisplayMenu();
            string choice = GetChoice();

            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity(
                    "Breathing Activity",
                    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."));
                    break;

                case "2":
                    RunActivity(new ReflectionActivity(
                        "Reflecting Activity",
                        "This activity will help you reflect on times in your life when you have shown strength or resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."));
                    break;

                case "3":
                    RunActivity(new ListingActivity(
                        "Listing Activity",
                        "This activity will help you focus on the positive by listing as many good things as you can in a certain area."));
                    break;

                // Exceeded expectations by adding a number guessing activity.
                case "4":
                    RunActivity(new GuessingActivity(
                        "Guessing Activity",
                        "This activity challenges you to guess the secret number between 1 and 100 before the timer runs out! If you guess wrong, it will let you know if the number is higher or lower than what you just guessed. Good luck!"));
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nThe program will now end. May God be with you till we meet again!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again!");
                    break;
            }
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Start guessing activity");
        Console.WriteLine("5. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public static string GetChoice()
    {
        return Console.ReadLine() ?? "";
    }

    public static void RunActivity(Activity activity)
    {
        activity.DisplayStartingMessage();
        activity.GetType().GetMethod("RunActivity")?.Invoke(activity, null);
        activity.DisplayEndingMessage();
    }
}

// Added a number guessing game to help exceed the expectations. Though it still displays the "Well done!!" even if you fail to guess the number in time.
// So, I made the program say that everyone is a winner and you at least tried to guess, and then it shows the usual "Well done!!" thing haha.
// I'm thankful for both Stackoverflow and w3schools for being useful websites to help me in times I am not sure how to do certain things.
// I did the best I could with this as it seems to do what it's supposed to, but I don't think the Console.Clear() always works like it's supposed to.