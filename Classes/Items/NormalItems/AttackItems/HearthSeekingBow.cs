using System;

namespace Classes
{
    public class HearthSeekingBow : OffensiveItem
    {
        public HearthSeekingBow(string name = "Hearth-seeking Bow")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 55;
        }
    }
}