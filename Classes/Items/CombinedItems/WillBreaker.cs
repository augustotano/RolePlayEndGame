// FrostMourne + DemonicClaws
using System;

namespace Classes
{
    public class WillBreaker : OffensiveItem
    {
        public WillBreaker(string name = "Will-Breaker")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 120;
        }
    }
}