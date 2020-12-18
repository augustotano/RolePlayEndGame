using System;
using System.Collections.Generic;

namespace Classes
{
    public class ChosenOne : CharacterClass
    {
        public int Lives {get; set;}

        public ChosenOne(string name = "Aragorn")
        {
            this.Name = name;

            this.HealthMax = 85;
            this.HealthActual = 85;
            this.Lives = 1;

            this.BaseAttackPower = 20;
            this.BaseDefensePower = 20;
            
            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new EternalStone();

            this.VictoryPoints = 0;
        }

        public override void ReceiveDamage(int damage)
        {
            int defensePower = this.BaseDefensePower;

            foreach(DefensiveItem item in this.ItemList)
            {
                defensePower += item.DefensePower;
            }

            foreach(MixItem item in this.ItemList)
            {
                defensePower += item.DefensePower;
            }

            int actualDamage = damage - defensePower;

            if(actualDamage > 0)
            {
                this.HealthActual -= actualDamage;
                if(this.HealthActual < 0)
                {
                    this.HealthActual = 0;
                }
                Console.WriteLine($"{this.Name} has been damaged for {actualDamage} health points. {this.HealthActual} points still left until his death.");
            }
            else
            {
                Console.WriteLine("Despite the attack, not even a scratch as a result!");
            }

            if(this.HealthActual <= 0 && this.Lives > 0)
            {
                this.HealthActual = 1;
                this.BaseAttackPower += 30;
                this.Lives -= 1;
                Console.WriteLine($"{this.Name} falls to the ground. But as he's about to take his last breath, he stands on his feet once more. {this.Name} is filled with DETERMINATION.");
            }
        }
    }
}