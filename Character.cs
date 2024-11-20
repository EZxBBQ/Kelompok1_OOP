using System;

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public Character(string name, int health, int attack, int defense)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
    }

    public void TakeDamage(int damage)
    {
        int damageTaken = damage - Defense;
        if (damageTaken > 0)
        {
            Health -= damageTaken;
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}