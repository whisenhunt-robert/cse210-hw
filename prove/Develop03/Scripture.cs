using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    // Added this random and int as part of exceeding expectations.
    // Though I don't think it's really randomizing if it'll show one of multiple verses...
    private Random _rand = new Random();
    private int _difficultyLevel;

    public Scripture(string text, Reference reference, int difficultyLevel)
    {
        _reference = reference;
        // Added this as part of my exceed expectations.
        _difficultyLevel = difficultyLevel;

        string[] splitWords = text.Split(' ');
        _words = new List<Word>();
        foreach (string word in splitWords)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideWords()
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            return;
        }

        int wordsToHide = Math.Min(_difficultyLevel, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            // This avoids re-hiding the same word.
            visibleWords.RemoveAt(index);
        }
    }

    public void DisplayScripture(bool showReference = true)
    {
        if (showReference)
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
        }

        foreach (Word word in _words)
        {
            Console.Write(word.DisplayScripture() + " ");
        }
        Console.WriteLine();
    }
    
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}