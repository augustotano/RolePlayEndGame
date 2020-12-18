using System;

namespace Classes
{
    public class DragonPlate : DefensiveItem
    {
        public DragonPlate(string name = "Dragon Plate")
        {
            this.Name = name;
            this.Magical = false;

            this.DefensePower = 30;
        }
    }
}