using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    public class Wizard : CharacterClass
    {
        SpellBook BookOfSpells {get; set;}

        public Wizard(string name = "Wizard")
        {
            this.Name = name;

            this.HealthMax = 70;
            this.HealthActual = 70;
            this.BaseAttackPower = 15;
            this.BaseDefensePower = 15;
            this.MagicalyEnabled = true;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.BookOfSpells = new SpellBook();
            this.Registres = new BookOfWisdom();

            this.VictoryPoints = 0;
        }


        public override void ReceiveDamage(int damage)
        {
            int defensePower = this.BaseDefensePower + this.BookOfSpells.UseAttackSpell();
            IEnumerable<DefensiveItem> defensiveItems = this.ItemList.OfType<DefensiveItem>();
            IEnumerable<MixItem> mixItems = this.ItemList.OfType<MixItem>();

            foreach(DefensiveItem item in defensiveItems)
            {
                defensePower += item.DefensePower;
            }

            foreach(MixItem item in mixItems)
            {
                defensePower += item.DefensePower;
            }

            int actualDamage = damage - defensePower;

            if(actualDamage > 0)
            {
                this.HealthActual -= actualDamage;
                if(this.HealthActual > 0)
                {
                    Console.WriteLine($"{this.Name} has been damaged for {actualDamage} health points. {this.HealthActual} points still left until his death.");
                }
                else
                {
                    this.HealthActual = 0;
                    Console.WriteLine($"{this.Name} has died at the hands of the enemy.");
                }
                
            }
            else
            {
                Console.WriteLine("Despite the attack, not even a scratch as a result!");
            }
        }

        public override int Attack()
        {
            int attackPower = this.BaseAttackPower + this.BookOfSpells.UseAttackSpell();
            IEnumerable<OffensiveItem> offensiveItems = this.ItemList.OfType<OffensiveItem>();
            IEnumerable<MixItem> mixItems = this.ItemList.OfType<MixItem>();

            foreach(OffensiveItem item in offensiveItems)
            {
                attackPower += item.AttackPower;
            }

            foreach(MixItem item in mixItems)
            {
                attackPower += item.AttackPower;
            }

            Console.WriteLine($"{this.Name} attacks with all his might. Attack Power: {attackPower}");

            return attackPower;
        }
        
    }
}