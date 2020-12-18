// Aegis + Excalibur
using System;

namespace Classes
{
    public class Avalon : MixItem
    {
        public Avalon(string name = "Avalon")
        {
            this.Name = name;
            this.Magical = true;

            this.AttackPower = 100;
            this.DefensePower = 80;
        }
    }
}