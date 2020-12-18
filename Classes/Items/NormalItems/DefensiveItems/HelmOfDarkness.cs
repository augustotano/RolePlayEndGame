using System;

namespace Classes
{
    public class HelmOfDarkness : DefensiveItem
    {
        public HelmOfDarkness(string name = "Helm of Darkness")
        {
            this.Name = name;
            this.Magical = false;

            this.DefensePower = 15;
        }
    }
}