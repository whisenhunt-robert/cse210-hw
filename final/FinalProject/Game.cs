using System;

public abstract class Game
{
    protected string _name;
    protected int _levelRequired;

    public Game(string name, int levelRequired)
    {
        _name = name;
        _levelRequired = levelRequired;
    }

    public string Name
    {
        get { return _name; }
    }

    public int LevelRequired
    {
        get { return _levelRequired; }
    }

    public virtual int GetTokenCost()
    {
        // How many tokens required to play games.
        return 10;
    }

    public abstract int Play();
    public abstract string GetSaveString();
}