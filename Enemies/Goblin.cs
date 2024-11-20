using System;

public class Goblin : Enemy
{
    public Goblin(int level)
        : base("Goblin", level, 50 + level * 10, 10 + level * 2, 5 + level, 20 + level * 5, 10 + level * 2, "Goblin Ear")
    {
    }
}