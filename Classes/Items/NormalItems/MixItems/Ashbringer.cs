using System;

namespace Classes
{
    public class Ashbringer : MixItem
    {
        public Ashbringer(string name = "Ashbringer")
        {
            this.Name = name;
            this.Magical = true;

            this.AttackPower = 75;
            this.DefensePower = 20;
        }
    }
}