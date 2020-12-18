using System;

namespace Classes
{
    public class BasicSword : OffensiveItem
    {
        public BasicSword(string name = "Basic Sword")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 30;
        }
    }
}