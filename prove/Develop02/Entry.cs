using System;

public class Entry
{
    // Stores the date, prompts shown to the user, and responses to the prompt to a private field.
    private string _date;
    private string _prompt;
    private string _userInput;

    public void SetEntry(string date, string prompt, string userInput)
    {
        _date = date;
        _prompt = prompt;
        _userInput = userInput;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} | {_prompt}");
        Console.WriteLine($"{_userInput}\n");
    }

    public string GetDate()
    {
        return _date;
    }
    public string GetPrompt()
    {
        return _prompt;
    }
    public string GetUserInput()
    {
        return _userInput;
    }
}