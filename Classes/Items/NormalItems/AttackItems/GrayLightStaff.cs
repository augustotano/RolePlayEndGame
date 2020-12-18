using System;

namespace Classes
{
    public class GrayLightStaff : OffensiveItem
    {
        public GrayLightStaff(string name = "Gray-light Staff")
        {
            this.Name = name;
            this.Magical = true;

            this.AttackPower = 60;
        }
    }
}