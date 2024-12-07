using System;
using System.Collections.Generic;

namespace GameSimulation
{
    public class Game
    {
        private Player player;
        private List<Player> characters;
        private List<Enemy> enemies;
        private Store store;
        private bool isRunning;

        public Game()
        {
            this.enemies = new List<Enemy> { new Deadliner(), new Overloader(), new Procrastinator() };
            this.store = new Store();
            this.isRunning = true;
        }

        public void Start()
        {
            // method dipanggil otomatis saat objek GameSystem dibuat
            SelectCharacter();

            while (isRunning)
            {
                DisplayMenu();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Go to battleground");
            Console.WriteLine("2. View player stats");
            Console.WriteLine("3. Visit store");
            Console.WriteLine("4. Quit game");
            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartBattle();
                    break;
                case "2":
                    player.DisplayStatus();
                    break;
                case "3":
                    store.DisplayItems();
                    Console.WriteLine("Enter item name to buy:");
                    string itemName = Console.ReadLine();
                    store.BuyItem(itemName, player);
                    break;
                case "4":
                    Console.WriteLine("Exiting game...");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void StartBattle()
        {
            if (new Random().Next(100) < 5) // 5% peluang bertemu NPC
            {
                MeetNPC();
            }

            Enemy enemy = enemies[new Random().Next(enemies.Count)];
            CombatSystem combatSystem = new CombatSystem(player, enemy);
            combatSystem.StartBattle();
        }


//====================


        // method untuk memilih tipe karakter
        private void SelectCharacter()
        {
            characters = new List<Player> { new MahasiswaChill(), new MahasiswaIdaman(), new MahasiswaKupuKupu() };
            Console.WriteLine("Choose Character : ");
            for (int i = 0; i < characters.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {characters[i].characterName}");
            }
            Console.Write("Enter choice : ");
            int choice = int.Parse(Console.ReadLine());

            if (choice > 0 && choice <= characters.Count)
            {
                player = characters[choice - 1];
                Console.WriteLine($"You choose {player.characterName}.");
            }
            else
            {
                Console.WriteLine("Option not available. try again...");
                SelectCharacter();
            }
        }

        // method untuk menentukan efek NPC pada player
        private void MeetNPC()
        {
            Console.WriteLine("You meet a friendly NPC!");
            Random rnd = new Random();
            if (rnd.Next(2) == 0)
            {
                int coins = rnd.Next(10, 21); // NPC gives between 10 to 20 coins
                player.Coins += coins;
                Console.WriteLine($"The NPC gives you {coins} coins!");
            }
            else
            {
                List<Item> availableItems = Inventory.GetAvailableItems(); // mengambil jenis-jenis item dari InventorySystem.cs
                Item randomItem = availableItems[rnd.Next(availableItems.Count)]; // memilih satu jenis item random
                player.Inventory.AddItem(randomItem);
                Console.WriteLine($"The NPC gives you a {randomItem.Name}!");
            }
        }
    }
}
