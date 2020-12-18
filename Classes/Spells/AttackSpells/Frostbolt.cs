using System;

namespace Classes
{
    public abstract class Frostbolt : AttackSpell
    {   

        public Frostbolt (string name = "Frost-bolt", string description = "The Wizard fires a bolt of frost.") : base (name, description)
        {
            this.AttackPower = 50;
        }

    }
}