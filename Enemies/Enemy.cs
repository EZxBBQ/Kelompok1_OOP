using System;

public class Enemy : Character
{
    public int Level { get; set; }
    public int ExpDrop { get; set; }
    public int MoneyDrop { get; set; }
    public string ItemDrop { get; set; }

    public Enemy(string name, int level, int health, int attack, int defense, int expDrop, int moneyDrop, string itemDrop)
        : base(name, health, attack, defense)
    {
        Level = level;
        ExpDrop = expDrop;
        MoneyDrop = moneyDrop;
        ItemDrop = itemDrop;
    }
}