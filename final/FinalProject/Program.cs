using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private List<Objective> _objectives = new List<Objective>();
    private List<Game> _games = new List<Game>();
    private int _tokens = 0;
    private int _experience = 0;
    private int _level = 1;

    static void Main(string[] args)
    {
        new Program().Run();
    }

    public Program()
    {
        _games.Add(new MagicNumber("Magic Number", 1));
    }

    public void Run()
    {
        int choice = 0;

        while (choice != 5)
        {
            DisplayMainMenu();
            choice = GetChoice();
            RunAction(choice);
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine($"Level: {_level} | EXP: {_experience} | Tokens: {_tokens}");
        Console.WriteLine("~ ~ ~ ~ Main Menu ~ ~ ~ ~");
        Console.WriteLine("1. Objectives");
        Console.WriteLine("2. Games");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
    }

    private int GetChoice()
    {
        Console.Write("Select a choice from the menu: ");
        return int.Parse(Console.ReadLine());
    }

    public void RunAction(int choice)
    {
        switch (choice)
        {
            case 1:
                DisplayObjectivesMenu();
                break;

            case 2:
                DisplayGamesMenu();
                break;

            case 3:
                Save();
                break;

            case 4:
                Load();
                break;

            case 5:
                Quit();
                break;

            default: Console.WriteLine("Invalid options. Please try again.");
            break;
        }
    }

    // Objectives Menu
    private void DisplayObjectivesMenu()
    {
        int choice = 0;
        
        while (choice != 3)
        {
            Console.WriteLine($"Level: {_level} | EXP: {_experience} | Tokens: {_tokens}");
            Console.WriteLine("~ ~ ~ ~ Objectives Menu ~ ~ ~ ~");
            Console.WriteLine("1. Create an Objective");
            Console.WriteLine("2. Complete an Objective");
            Console.WriteLine("3. Return to the Main Menu");

            choice = GetChoice();

            switch (choice)
            {
                case 1:
                    CreateObjective();
                    break;

                case 2:
                    CompleteObjective();
                    break;

                case 3:
                    return;

                default: Console.WriteLine("Invalid option. Please try again.");
                break;
            }
        }
    }

    private void CreateObjective()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();

        SimpleObjective obj = new SimpleObjective(name, desc, 50);
        _objectives.Add(obj);

        Console.WriteLine("Objective successfully added.");
    }

    private void CompleteObjective()
    {
        if (_objectives.Count == 0)
        {
            Console.WriteLine("There are no objectives to complete. Please create one first.");
            return;
        }

        Console.WriteLine("\n~ ~ ~ ~ Objectives you've created ~ ~ ~ ~");

        for (int i = 0; i < _objectives.Count; i++)
            Console.WriteLine((i + 1) + ". " + _objectives[i].GetStatus());

        Console.Write("\nWhich objective did you complete: ");
        int index = int.Parse(Console.ReadLine());

        int points = _objectives[index].RecordEvent();
        _tokens += points;

        Console.WriteLine("Congratulations! You earned 50 tokens for completing this objective!");
    }

    // Games Menu
    private void DisplayGamesMenu()
    {
        Console.WriteLine($"Level: {_level} | EXP: {_experience} | Tokens: {_tokens}");
        Console.WriteLine("~ ~ ~ ~ Games Menu ~ ~ ~ ~");

        for (int i = 0; i < _games.Count; i++)
        {
            Game g = _games[i];

            if (_level >= g.LevelRequired)
                Console.WriteLine((i + 1) + ". " + g.Name);
            else
                Console.WriteLine((i + 1) + ". " + g.Name + " (LOCKED - Level " + g.LevelRequired + ")");
        }

        Console.WriteLine("Please choose a game or press 0 to return to the main menu:");
        int choice = GetChoice();

        if (choice == 0)
            return;

        Game selected = _games[choice - 1];

        if (_level < selected.LevelRequired)
        {
            Console.WriteLine("You are not high enough level to play that game!");
            return;
        }

        int cost = selected.GetTokenCost();

        if (_tokens < cost)
        {
            Console.WriteLine("You don't have enough tokens to play that game!");
            return;
        }

        _tokens -= cost;
        int expEarned = selected.Play();

        Console.WriteLine("You earned " + expEarned + "experinece points!");
        AddExperience(expEarned);
    }

    // Expereince Points and Levels
    private void AddExperience(int amount)
    {
        _experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int[] expThresholds =
        {
            // How much EXP is needed for each level.
            0,
            100,
            300,
            500,
            1000,
            1500,
            2000,
            2500,
            3000,
            4000,
        };

        // Used a while loop so that the user can level up multiple times if earned enough EXP.
        while (_level < 10 && _experience >= expThresholds[_level])
        {
            _level++;
            Console.WriteLine("\n---- LEVEL UP ----");
            Console.WriteLine($"You are now Level {_level}!");
        }
    }

    private void Save()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        List<string> lines = new List<string>();
        lines.Add(_tokens.ToString());
        lines.Add(_level.ToString());
        lines.Add(_experience.ToString());

        foreach (Objective o in _objectives)
            lines.Add(o.GetSaveString());

        File.WriteAllLines(file, lines);

        Console.WriteLine("File saved successfully.\n");
    }

    public void Load()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);

        _tokens = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _experience = int.Parse(lines[2]);
        _objectives.Clear();

        for (int i = 3; i < lines.Length; i++)
        {
            string[] p = lines[i].Split("|");
            SimpleObjective so = new SimpleObjective(
                p[1],
                p[2],
                int.Parse(p[3]),
                bool.Parse(p[4]));
            _objectives.Add(so);
        }

        Console.WriteLine("File loaded successfully.\n");
    }

    public void Quit()
    {
        Console.WriteLine("\nMay God be with you till we meet again.\n");
        Environment.Exit(0);
    }
}