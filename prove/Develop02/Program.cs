using System;

class Program
{
    static void Main()
    {
        // Creates a new instance for the Journal class.
        Journal journal = new Journal();
        // Creates a new instance for the PromptGenerator class.
        PromptGenerator promptGenerator = new PromptGenerator();

        // A while loop that displays the menu until the user decides to Quit.
        while (true)
        {
            // Displays the menu to the user.
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            // Prompts the user to enter the number they choose from the menu.
            Console.WriteLine("What would you like to do? ");

            // Reads the user's choice as a string.
            string choice = Console.ReadLine();
            // Creates a line break following the choice being made.
            Console.WriteLine();

            // A switch statement too handle each of the menu options based on the user's input.
            switch (choice)
            {
                // Option 1: Write
                case "1":
                    // Sets the current date to the currentDate variable.
                    string currentDate = DateTime.Now.ToShortDateString();
                    // Delivers a random prompt frm the prompt generator to the user.
                    string prompt = promptGenerator.RandomPrompt();
                    // Takes the prompt and response and adds it as a new journal entry.
                    journal.AddEntry();
                    // Prints a message letting the user know the entry was added.
                    Console.WriteLine("Your entry has been added.\n");
                    break;

                // Option 2: Display
                case "2":
                    // Calls the method to display entries.
                    journal.DisplayEntries();
                    break;

                // Option 3: Load
                case "3":
                    // Prompts the user to enter the name of the file they wish to load.
                    Console.Write("Please enter the filename you wish to load from: ");
                    // Reads the file name the user input.
                    string loadFile = Console.ReadLine();
                    // Calls the method to load the journal entries from the file the user requested.
                    journal.LoadFromFile(loadFile);
                    break;

                // Option 4: Save
                case "4":
                    // Prompts the user to enter the name of the file they wish to save.
                    Console.Write("Please enter the filename to save the journal: ");
                    // Reads the file name the user input.
                    string saveFile = Console.ReadLine();
                    // Calls the method to save the journal entries to the file the user requested.
                    journal.SaveToFile(saveFile);
                    // Prints a message to let the user know it saved successfully.
                    Console.WriteLine("File saved.\n");
                    break;

                case "5":
                    // Prints a farewell message to the user.
                    Console.WriteLine("May God be with you till we meet again!");
                    // Exits the program.
                    return;

                default:
                    // Prints a message to let the user know their input was invalid.
                    Console.WriteLine("That is an invalid choice, please try again.\n");
                    break;
            }
        }
    }
}

// I was encouraged by one of the students on my team to use citations for things I used to help figure out the "how" in my program.
// I forgot which answers I used exactly to be able to provide a direct link, but I took the advice you gave regarding using stackoverflow.
// I remember typing questions such as "How do I make a multiple choice program in C#?" and "How do I make a menu in C#?" to find out things like that.
// I'm sorry in advance that I didn't get to finish adding good comments to my class files. But made sure to add comments to this at least.
// I was told that just having the PromptGenerator class counted as exceeding expectations. I wanted to find a way to delete a .csv file by entering the file name.
// I had trouble finding the write wording to find the "how" on stackoverflow for that; so, I'm hoping my team member was right.
// Also, I did my best to follow the diagram I created, which if I read it correctly, the three strings in Entry.cs were set to private, which I used stackoverflow for that as well.
// The program does what it's supposed to do, as I tested it many times. I just hope how I wrote it is alright, because my team members said on Thursday that they set theirs to public.