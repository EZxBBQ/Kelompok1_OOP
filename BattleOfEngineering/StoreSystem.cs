
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameSimulation
{
    public class Store
    {
        public List<Item> ItemsForSale { get; set; }

        public Store()
        {
            ItemsForSale = new List<Item>
            {
                new HealthPotion(),
                new DefenseBoost()
            };
        }

        public void DisplayItems()
        {
            Console.WriteLine("Items for sale:");
            foreach (Item item in ItemsForSale)
            {
                Console.WriteLine($"{item.Name} - {item.Description}");
            }
        }

        public void BuyItem(string itemName, Player player)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                Console.WriteLine("Invalid item name.");
                return;
            }

            Item item = ItemsForSale.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null && player.Coins >= 10)
            {
                player.Inventory.AddItem(item);
                player.Coins -= 10;
                ItemsForSale.Remove(item);
                Console.WriteLine($"{itemName} purchased and added to your inventory.");
            }
            else if (item != null)
            {
                Console.WriteLine("Not enough coins to purchase this item.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

    }
}
