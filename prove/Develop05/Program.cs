using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    // Added a level-up system to exceed expectations.
    private int _level = 1;
    // Gets the date to prepare to reset your points and level each month.
    private DateTime _lastResetDate = DateTime.Now;

    static void Main(string[] args)
    {
        new Program().Run();
    }

    public void Run()
    {
        // Part of exceeding expectations.
        monthlyReset();
        
        int choice = 0;

        while (choice != 6)
        {
            DisplayMenu();
            choice = GetChoice();
            RunAction(choice);
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine($"Level: {_level} | EXP: {_score}\n");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
    }

    public int GetChoice()
    {
        Console.Write("Select a choice from the menu: ");
        return int.Parse(Console.ReadLine());
    }

    public void RunAction(int choice)
    {
        switch (choice)
        {
            case 1:
                CreateGoal();
                break;

            case 2:
                DisplayGoals();
                break;

            case 3:
                Save();
                break;

            case 4:
                Load();
                break;

            case 5:
                RecordEvent();
                break;

            case 6:
                Quit();
                break;
        }
    }

    // Creates a Goal.
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int pts = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, desc, pts));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, desc, pts));
                break;

            case 3:
                Console.Write("Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                Console.Write("Times Needed: ");
                int need = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, desc, pts, bonus, need));
                break;
        }
    }

    // Display the goals.
    public void DisplayGoals()
    {
        Console.WriteLine("Your goals are:");
        int index = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{index}. {g.GetStatus()}");
            index++;
        }
    }

    // Save the file.
    public void Save()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        List<string> lines = new List<string>();
        lines.Add(_score.ToString());
        lines.Add(_level.ToString());
        lines.Add(_lastResetDate.ToString("O"));

        foreach (Goal g in _goals)
            lines.Add(g.GetSaveString());

        File.WriteAllLines(file, lines);

        Console.WriteLine("File saved successfully.\n");
    }

    // Loads the file.
    public void Load()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        _lastResetDate = DateTime.Parse(lines[2]);
        _goals.Clear();

        for (int i = 3; i < lines.Length; i++)
        {
            _goals.Add(ParseGoal(lines[i]));
        }

        Console.WriteLine("File loaded successfully.\n");
    }

    private Goal ParseGoal(string line)
    {
        string[] p = line.Split("|");
        string type = p[0];

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4]));

            case "EternalGoal":
                return new EternalGoal(p[1], p[2], int.Parse(p[3]));

            case "ChecklistGoal":
                return new ChecklistGoal(p[1], p[2], int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]), int.Parse(p[6]));

            default:
                throw new Exception("Unknown goal type.");
        }
    }

    // Record the Event.
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        DisplayGoals();
        Console.Write("Which goal did you accomplish? ");

        int index = int.Parse(Console.ReadLine()) - 1;

        int pts = _goals[index].RecordEvent();
        _score += pts;

        Console.WriteLine($"Congratulations! You earned {pts} EXP!");
        // Checks to see if you earned enough EXP to level up.
        CheckLevelUp();
    }

    // Creates the level up system.
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
        while (_level < 10 && _score >= expThresholds[_level])
        {
            _level++;
            Console.WriteLine("\n---- LEVEL UP ----");
            Console.WriteLine($"You are now Level {_level}!");
        }
    }
    
    // Resets the system each month.
    private void monthlyReset()
    {
        if (_lastResetDate.Month != DateTime.Now.Month || _lastResetDate.Year != DateTime.Now.Year)
        {
            Console.WriteLine("\nYou have entered a new month. Your Level and EXP have been reset.");
            _score = 0;
            _level = 1;
            _lastResetDate = DateTime.Now;
        }
    }

    // Closes the file.
    public void Quit()
    {
        Console.WriteLine("\nMay God be with you till we meet again.\n");
    }
}