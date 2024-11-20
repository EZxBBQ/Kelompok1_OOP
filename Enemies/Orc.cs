using System;

public class Orc : Enemy
{
    public Orc(int level)
        : base("Orc", level, 100 + level * 20, 20 + level * 3, 10 + level * 2, 50 + level * 10, 20 + level * 5, "Orc Tooth")
    {
    }
}