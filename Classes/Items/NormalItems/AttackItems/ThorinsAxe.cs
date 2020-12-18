using System;

namespace Classes
{
    public class ThorinsAxe : OffensiveItem
    {
        public ThorinsAxe(string name = "Thorin's axe")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 40;
        }
    }
}