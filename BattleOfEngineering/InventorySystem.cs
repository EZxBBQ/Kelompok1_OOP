
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameSimulation
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }

        public void UseItem(string itemName, Player player)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                Console.WriteLine("Invalid item name.");
                return;
            }

            var item = items.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.Use(player);
                items.Remove(item);
                Console.WriteLine($"{itemName} used.");
            }
            else
            {
                Console.WriteLine("Item not found in inventory.");
            }
        }

        // method untuk mendapat jenis item yang tersedia
        public static List<Item> GetAvailableItems()
        {
            return new List<Item>
            {
                new HealthPotion(),
                new DefenseBoost()
                // tambahkan item baru di sini
            };
        }
    }

    public abstract class Item
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Action<Player> Use { get; set; } = player => { };
    }

    public class HealthPotion : Item
    {
        public HealthPotion()
        {
            Name = "Health Potion";
            Description = "Restores 30 health points.";
            Use = player => player.Health += 30;
        }
    }

    public class DefenseBoost : Item
    {
        public DefenseBoost()
        {
            Name = "Defense Boost";
            Description = "Increases defense by 5 for the next battle.";
            Use = player => player.Defense += 5;
        }
    }
}
