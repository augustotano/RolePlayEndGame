using System;

namespace Classes
{
    /*
    Información en la clase abstracta.
    */
    public abstract class DefenseSpell : Spell
    {   
        public int DefensePower {get; set;}

        public DefenseSpell (string name, string description) : base (name, description)
        {
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.DefensePower;
        }
    }
}