using System;

namespace Classes
{
    public abstract class Fireball : AttackSpell
    {   

        public Fireball (string name = "Fire-ball", string description = "The Wizard fires a ball of fire.") : base (name, description)
        {
            this.AttackPower = 80;
        }

    }
}