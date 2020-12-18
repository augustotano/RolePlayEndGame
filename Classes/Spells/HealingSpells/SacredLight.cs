using System;

namespace Classes
{
    public abstract class SacredLight : HealingSpell
    {   

        public SacredLight (string name = "Sacred Light", string description = "As the Wizard lifts their wand, light rains from the heavens above.") : base (name, description)
        {
            this.HealingPower = 40;
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.HealingPower;
        }
    }
}