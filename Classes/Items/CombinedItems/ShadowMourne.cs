//StygianBlade + FrostMourne
using System;

namespace Classes
{
    public class ShadowMourne : OffensiveItem
    {
        public ShadowMourne(string name = "Shadow Mourne")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 110;
        }
    }
}