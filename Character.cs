using System;

public class Character
{
    public string Name { get; set; }
    public int? Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Character(string name, int? health, int attack, int defense)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
    }

    public void TakeDamage(int? damage)
    {
        int? damageTaken = damage - Defense / 5;
        if (damageTaken > 0)
        {

            Health -= damageTaken;
        }
    }

    public int? Menyerang(Random random)
    {
        return random.Next(Attack - 5, Attack + 5);
    }

    public void Defend()
    {
        Console.WriteLine("You brace yourself for the next attack, reducing damage taken.");
    }


    public bool IsAlive()
    {
        return Health > 0;
    }
}