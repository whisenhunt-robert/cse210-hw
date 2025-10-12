using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Creates a private list to hold all journal entries.
    private List<Entry> _entries;

    private PromptGenerator _promptGenerator;

    // Opens the journal with an empty list of entries.
    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

    // Adds a new journal entry based off the prompt and user's response.
    public void AddEntry()
    {
        string prompt = _promptGenerator.RandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        Entry entry = new Entry();
        entry.SetEntry(date, prompt, response);
        _entries.Add(entry);

        Console.WriteLine("Your entry was added successfully.");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.GetDate} | {entry.GetPrompt} | {entry.GetUserInput}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        foreach (string line in File.ReadLines(filename))
        {
            string[] index = line.Split("|");
            if (index.Length == 3)
            {
                string date = index[0].Trim();
                string prompt = index[1].Trim();
                string userInput = index[2].Trim();

                Entry entry = new Entry();
                entry.SetEntry(date, prompt, userInput);
                _entries.Add(entry);
            }
        }
    }
}