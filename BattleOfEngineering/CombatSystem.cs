
using System;

namespace GameSimulation
{
    public class CombatSystem
    {
        private Player player;
        private Enemy enemy;
        private bool isEscaped;

        public CombatSystem(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void StartBattle()
        {
            Console.WriteLine($"A battle starts against {enemy.Type}!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                PlayerTurn();
                if (enemy.Health > 0 && !isEscaped)
                {
                    EnemyTurn();
                }
                else if (isEscaped)
                {
                    break;
                }

                UpdateCooldowns();
            }

            isEscaped = false;

            if (player.Health > 0 && enemy.Health <= 0)
            {
                Console.WriteLine("Player wins the battle!");
                player.LevelUp();
            }
            else if (player.Health <= 0 && enemy.Health > 0) 
            {
                Console.WriteLine("Player has been defeated.");
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Player's turn.");
            Console.WriteLine("Choose an action: 1. Attack 2. Special Ability 3. Use Item 4. Escape");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    player.AttackEnemy(enemy);
                    break;
                case "2":
                    player.SpecialAbility(enemy);
                    break;
                case "3":
                    UsePlayerItem();
                    break;
                case "4":
                    if (AttemptEscape())
                    {
                        Console.WriteLine("Successfully escaped the battle!");
                        isEscaped = true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to escape. Enemy takes a turn.");
                        EnemyTurn();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Choose again.");
                    PlayerTurn();
                    break;
            }
        }

        private void EnemyTurn()
        {
            Console.WriteLine("Enemy's turn.");
            if (player.isSpecialAbilityActive)
            {
                player.isSpecialAbilityActive = false;
            }
            else
            {
                enemy.Attack(player);
            }   
        }

        private void UsePlayerItem()
        {
            Console.WriteLine("Enter item name to use:");
            string itemName = Console.ReadLine();
            player.Inventory.UseItem(itemName, player);
        }

        private bool AttemptEscape()
        {
            Random rnd = new Random();
            return rnd.Next(100) < player.Luck * 10;
        }


//====================


        // mengupdate cooldown dari special ability
        private void UpdateCooldowns()
        {
            if (player.specialAbilityCooldown > 0)
            {
                player.specialAbilityCooldown--;
            }

            if (player.debuffDuration > 0)
            {
                player.debuffDuration--;
                if (player.debuffDuration == 0)
                {
                    // Revert the debuff effects on the enemy
                    enemy.Health += 20;
                    enemy.AttackDamage -= 10;
                    Console.WriteLine("The debuff on the enemy has worn off.");
                }
            }
        }
    }
}
