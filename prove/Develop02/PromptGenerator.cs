using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "What happened today that you're most excited about?",
            "What happened today that put a smile on your face?",
            "What could have made this day a better day for you?",
            "Did anything happen today that made you anxious?",
            "How would you describe your mood currently after the kind of day you had?",
            "If you had one thing you could do over today, what would it be?",
            "What was the best part of your day?"
        };
    }

    public string RandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}