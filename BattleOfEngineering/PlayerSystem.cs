
using System;

namespace GameSimulation
{
    // player dibuat abstrak agar tidak bisa dibuat objek
    public abstract class Player
    {
        public string Name { get; set; }
        public string characterName { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public int Luck { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();
        public int Coins { get; set; }
        public int specialAbilityCooldown { get; set; }
        public bool isSpecialAbilityActive { get; set; }
        public int debuffDuration { get; set; }
        
        public Player()
        {
            Name = "Hero";
            Health = 100;
            Attack = 10;
            Defense = 5;
            Level = 1;
            Luck = 1;
            Coins = 50;
        }

        public void AttackEnemy(Enemy enemy)
        {
            Console.WriteLine($"{Name} attacks {enemy.Type} for {Attack} damage.");
            enemy.TakeDamage(Attack);
        }

        public void LevelUp()
        {
            Level++;
            Health += 20;
            Attack += 5;
            Defense += 3;

            if (characterName != "Mahasiswa Idaman")
            {
                Luck += 1;
            }
            
            Console.WriteLine($"{Name} has leveled up to level {Level}! Health: {Health}, Attack: {Attack}, Defense: {Defense}, Luck: {Luck}");
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{Name}'s Stats - Health: {Health}, Attack: {Attack}, Defense: {Defense}, Level: {Level}, Luck: {Luck}, Coins: {Coins}");
        }

        public abstract void SpecialAbility(Enemy enemy);
    }


//====================


    // memiliki luck jauh lebih besar dibanding tipe karakter lain
    public class MahasiswaChill : Player
    {
        public MahasiswaChill()
        {
            this.characterName = "Mahasiswa Chill";
            this.Health = base.Health;
            this.Attack = base.Attack;
            this.Defense = base.Defense;
            this.Luck = base.Luck + 5;
            this.specialAbilityCooldown = 0;
            this.isSpecialAbilityActive = false;
            this.debuffDuration = 0;
        }

        public override void SpecialAbility(Enemy enemy)
        {
            if (specialAbilityCooldown == 0)
            {
                Console.WriteLine($"{Name} is so chill that enemy attack dont work on him");
                isSpecialAbilityActive = true;
                specialAbilityCooldown = 7; // cooldown sebenarnya 6 turn
            }
            else
            {
                Console.WriteLine($"Mahasiswa Chill's Special ability is on cooldown ({specialAbilityCooldown}) turn left).");
            }
        }
    }

    // seluruh atribut lebih tinggi dibanding tipe karakter lain, namun tidak bisa meningkatkan luck
    public class MahasiswaIdaman : Player
    {
        public MahasiswaIdaman()
        {
            this.characterName = "Mahasiswa Idaman";
            this.Health = base.Health + 100;
            this.Attack = base.Attack + 10;
            this.Defense = base.Defense + 5;
            this.Luck = base.Luck;
            this.specialAbilityCooldown = 0;
            this.isSpecialAbilityActive = false;
            this.debuffDuration = 0;
        }

        public override void SpecialAbility(Enemy enemy)
        {
            if (specialAbilityCooldown == 0)
            {
                Console.WriteLine($"{Name} uses his aura to decrease enemy's health and defense, but its attack increase.");
                enemy.Health -= 20;
                enemy.AttackDamage += 10;
                debuffDuration = 3; // durasi sebenarnya 2 turn
                specialAbilityCooldown = 7; // cooldown sebenarnya 6 turn
            }
            else
            {
                Console.WriteLine($"Mahasiswa Idaman's Special ability is on cooldown ({specialAbilityCooldown}) turn left).");
            }
        }
    }

    // memiliki attack paling tinggi namun health paling rendah
    public class MahasiswaKupuKupu : Player
    {
        public MahasiswaKupuKupu()
        {
            this.characterName = "Mahasiswa Kupu-Kupu";
            this.Health = base.Health - 20;
            this.Attack = base.Attack + 20;
            this.Defense = base.Defense;
            this.Luck = base.Luck;
            this.specialAbilityCooldown = 0;
            this.isSpecialAbilityActive = false;
            this.debuffDuration = 0;
        }

        public override void SpecialAbility(Enemy enemy)
        {
            if (specialAbilityCooldown == 0)
            {
                Console.WriteLine($"{Name} quickly go home and return to battle. fully restore health.");
                this.Health = 80;
                specialAbilityCooldown = 11; // cooldown sebenarnya 10 turn
            }
            else
            {
                Console.WriteLine($"Mahasiswa Kupu-Kupu's Special ability is on cooldown ({specialAbilityCooldown}) turn left).");
            }
        }
    }
}
