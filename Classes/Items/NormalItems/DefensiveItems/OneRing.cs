using System;

namespace Classes
{
    public class OneRing : DefensiveItem
    {
        public OneRing(string name = "The One Ring")
        {
            this.Name = name;
            this.Magical = true;

            this.DefensePower = 5;
        }
    }
}