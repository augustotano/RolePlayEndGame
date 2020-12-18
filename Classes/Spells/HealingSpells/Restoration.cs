using System;

namespace Classes
{
    public abstract class Restoration : HealingSpell
    {   

        public Restoration (string name = "Restoration", string description = "A light emanates from the Wizard's wand, restoring simple wounds.") : base (name, description)
        {
            this.HealingPower = 20;
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.HealingPower;
        }
    }
}