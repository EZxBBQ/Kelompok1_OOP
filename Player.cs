using System;

public class Player : Character, IObserver
{
    public int Money { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int LevelUpPoints { get; private set; }
    private int experienceToNextLevel;

    public Player(string name, int health, int attack, int defense, int money, int level)
        : base(name, health, attack, defense)
    {
        Money = money;
        Level = level;
        Experience = 0;
        LevelUpPoints = 0;
        experienceToNextLevel = CalculateExperienceToNextLevel();
    }

    private int CalculateExperienceToNextLevel()
    {
        return Level * 50; // formula for leveling up
    }

    public void GainExperience(int exp)
    {
        Experience += exp;
        while (Experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        Experience -= experienceToNextLevel;
        experienceToNextLevel = CalculateExperienceToNextLevel();
        LevelUpPoints++;
        Console.WriteLine($"Level up! You are now level {Level}. You have {LevelUpPoints} level up points to spend.");
    }

    public void AllocatePointToHealth()
    {
        if (LevelUpPoints > 0)
        {
            Health += 10;
            LevelUpPoints--;
            Console.WriteLine("Allocated 1 point to Health.");
        }
        else
        {
            Console.WriteLine("No level up points available.");
        }
    }

    public void AllocatePointToAttack()
    {
        if (LevelUpPoints > 0)
        {
            Attack += 2;
            LevelUpPoints--;
            Console.WriteLine("Allocated 1 point to Attack.");
        }
        else
        {
            Console.WriteLine("No level up points available.");
        }
    }

    public void AllocatePointToDefense()
    {
        if (LevelUpPoints > 0)
        {
            Defense += 2;
            LevelUpPoints--;
            Console.WriteLine("Allocated 1 point to Defense.");
        }
        else
        {
            Console.WriteLine("No level up points available.");
        }
    }

    public void Update(Enemy enemy)
    {
        GainExperience(enemy.ExpDrop);
        Money += enemy.MoneyDrop;
        // Handle item drop logic here
        Console.WriteLine($"Defeated {enemy.Name}, gained {enemy.ExpDrop} EXP and {enemy.MoneyDrop} money.");
    }
}