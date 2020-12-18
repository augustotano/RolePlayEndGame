using System;

namespace Classes
{
    public class LichArmor : DefensiveItem
    {
        public LichArmor(string name = "Lich King's Armor")
        {
            this.Name = name;
            this.Magical = false;

            this.DefensePower = 40;
        }
    }
}