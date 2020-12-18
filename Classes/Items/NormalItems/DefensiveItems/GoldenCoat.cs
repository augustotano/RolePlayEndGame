using System;

namespace Classes
{
    public class GoldenCoat : DefensiveItem
    {
        public GoldenCoat(string name = "Golden Coat")
        {
            this.Name = name;
            this.Magical = false;

            this.DefensePower = 10;
        }
    }
}