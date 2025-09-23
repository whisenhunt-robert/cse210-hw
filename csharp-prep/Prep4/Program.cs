using System;

class Program
{
    static void Main(string[] args)
    {
        // Creates a list called numbers.
        List<int> numbers;
        // Confirms the new list using the "new" method.
        numbers = new List<int>();

        // Explains to the user to enter a list of numbers, and to press 0 when they're finished.
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // Integer variable to set the default response to "1".
        int entry = 1;

        // While loop that repeats until the user enters a 0.
        while (entry != 0)
        {
            // Prompts the user to enter a number.
            Console.Write("Enter number: ");
            // Returns the user's number and updates the variable into a string.
            string response = Console.ReadLine();
            // Creates the entry variable using the number the user just entered.
            entry = int.Parse(response);

            // Adds the number the user enter to the list if the user didn't enter a 0.
            if (entry != 0)
            {
                numbers.Add(entry);
            }

            // Interger variable that sets the default sum to 0.
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            // Prints what the sum of the numbers are.
            Console.WriteLine($"The sum is: {sum}");

            // Float variable that gets the average of the numbers.
            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Integer variable that sets the current largest number to 0.
            int largestNumb = numbers[0];

            foreach (int number in numbers)
            {
                if (number > largestNumb)
                {
                    largestNumb = number;
                }
            }

            // Prints what the largest number is.
            Console.WriteLine($"The largest number is: {largestNumb}");
        }
    }
}