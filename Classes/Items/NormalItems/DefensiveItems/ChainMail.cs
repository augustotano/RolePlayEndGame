using System;

namespace Classes
{
    public class ChainMail : DefensiveItem
    {
        public ChainMail(string name = "Chain Mail")
        {
            this.Name = name;
            this.Magical = false;

            this.DefensePower = 20;
        }
    }
}