using System;
using System.Collections.Generic;

public class GameManager
{
    private Player? player; // ? makes sure player is not throwing error when null
    private EnemyManager enemyManager;
    private Random random;

    public GameManager()
    {
        enemyManager = new EnemyManager();
        random = new Random();
    }

    public void Start()
    {
        Console.WriteLine("===== Welcome to Tower Climber =====");
        Console.Write("Enter your player name: ");
        string? playerName = Console.ReadLine();

        if (string.IsNullOrEmpty(playerName))
        {
            Console.WriteLine("Invalid player name. Exiting game.");
            return;
        }

        player = new Player(playerName, 100, 15, 10, 0, 1);
        enemyManager.Attach(player);

        while (true)
        {
            DisplayPlayerStats();
            Console.WriteLine("You can move by typing 'north', 'south', 'east', or 'west'.");
            Console.WriteLine("Type 'exit' to quit the game.");
            Console.Write("Enter your move: ");
            string? input = Console.ReadLine();

            string? lowerCaseInput = input?.ToLower();

            if (lowerCaseInput == "exit")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }

            HandleMovement(lowerCaseInput);
            HandleLevelUpPoints();
        }
    }

    private void DisplayPlayerStats()
    {
        Console.WriteLine();
        Console.WriteLine($"Player Stats:");
        Console.WriteLine($"Name: {player?.Name}");
        Console.WriteLine($"Level: {player?.Level}");
        Console.WriteLine($"Health: {player?.Health}");
        Console.WriteLine($"Attack: {player?.Attack}");
        Console.WriteLine($"Defense: {player?.Defense}");
        Console.WriteLine($"Experience: {player?.Experience}");
        Console.WriteLine($"Money: {player?.Money}");
        Console.WriteLine();
    }

    private void HandleMovement(string? direction)
    {
        if (direction == "north" || direction == "south" || direction == "east" || direction == "west")
        {
            Console.WriteLine();
            Console.WriteLine($"You moved {direction}.");
            CheckForEnemyEncounter();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid move. Please enter 'north', 'south', 'east', or 'west'.");
        }
    }

    private void CheckForEnemyEncounter()
    {
        int encounterChance = random.Next(0, 100);
        if (encounterChance < 30) // 30% chance to encounter an enemy
        {
            Enemy enemy = GenerateRandomEnemy();
            Console.WriteLine();
            Console.WriteLine($"You encountered a {enemy.Name}!");
            // Placeholder for combat system
            enemyManager.EnemyDefeated(enemy);
        }
    }

    private Enemy GenerateRandomEnemy()
    {
        int enemyType = random.Next(0, 2);
        int enemyLevel = random.Next(1, (player?.Level ?? 1) + 2); // ? and ?? make sure player and its variabel is not throwing error when null

        if (enemyType == 0)
        {
            return new Goblin(enemyLevel);
        }
        else
        {
            return new Orc(enemyLevel);
        }
    }

    private void HandleLevelUpPoints()
    {
        while (player?.LevelUpPoints > 0)
        {
            Console.WriteLine("You have level up points to allocate.");
            Console.WriteLine("Enter 'health' to increase Health, 'attack' to increase Attack, or 'defense' to increase Defense.");
            string? input = Console.ReadLine();

            string? lowerCaseInput = input?.ToLower();

            switch (lowerCaseInput)
            {
                case "health":
                    player.AllocatePointToHealth();
                    break;
                case "attack":
                    player.AllocatePointToAttack();
                    break;
                case "defense":
                    player.AllocatePointToDefense();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please enter 'health', 'attack', or 'defense'.");
                    break;
            }
        }
    }
}