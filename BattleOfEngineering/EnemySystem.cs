
using System;

namespace GameSimulation
{
    public abstract class Enemy
    {
        public string Type { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }

        public Enemy(string type, int health, int attackDamage)
        {
            Type = type;
            Health = health;
            AttackDamage = attackDamage;
        }

        public virtual void Attack(Player player)
        {
            Console.WriteLine($"{Type} attacks {player.Name} for {AttackDamage} damage!");
            player.Health -= AttackDamage;
        }

        public virtual void SpecialAbility(Player player)
        {
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
                Console.WriteLine($"{Type} has been defeated.");
            else
                Console.WriteLine($"{Type} takes {damage} damage, remaining health: {Health}");
        }
    }

    public class Deadliner : Enemy
    {
        public Deadliner() : base("Deadliner", 60, 8) {}

        public override void SpecialAbility(Player player)
        {
            Console.WriteLine($"{Type} panics and launches a last-minute attack, increasing attack damage!");
            AttackDamage += 5;
        }
    }

    public class Overloader : Enemy
    {
        public Overloader() : base("Overloader", 80, 10) {}

        public override void SpecialAbility(Player player)
        {
            Console.WriteLine($"{Type} overwhelms {player.Name}, reducing their defense!");
            player.Defense -= 3;
        }
    }

    public class Procrastinator : Enemy
    {
        public Procrastinator() : base("Procrastinator", 50, 8) {}

        public override void SpecialAbility(Player player)
        {
            Console.WriteLine($"{Type} procrastinates and then regains focus, regenerating health!");
            Health += 20;
        }
    }
}
