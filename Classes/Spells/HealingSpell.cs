using System;

namespace Classes
{
    /*
    Información en la clase abstracta.
    */
    public abstract class HealingSpell : Spell
    {   
        public int HealingPower {get; set;}

        public HealingSpell (string name, string description) : base (name, description)
        {
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.HealingPower;
        }
    }
}