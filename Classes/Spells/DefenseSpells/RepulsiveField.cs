using System;

namespace Classes
{
    public abstract class RepulsiveField : DefenseSpell
    {   
        public RepulsiveField (string name = "Repulsive Field", string description = "The wizard conjures an energy fields that repels the attack.") : base (name, description)
        {
            this.DefensePower = 30;
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.DefensePower;
        }
    }
}