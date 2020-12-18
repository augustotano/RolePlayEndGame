using System;

namespace Classes
{
    /*
    Información en la clase abstracta.
    */
    public abstract class AttackSpell : Spell
    {   
        public int AttackPower {get; set;}

        public AttackSpell (string name, string description) : base (name, description)
        {
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.AttackPower;
        }
    }
}