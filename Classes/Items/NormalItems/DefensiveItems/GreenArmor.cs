using System;

namespace Classes
{
    public class GreenArmor : DefensiveItem
    {
        public GreenArmor(string name = "Green Armor")
        {
            this.Name = name;
            this.Magical = true;

            this.DefensePower = 40;
        }
    }
}