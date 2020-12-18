using System;
using System.Collections.Generic;

namespace Classes
{
    public class Elf : CharacterClass
    {
        public Elf(string name = "Elf")
        {
            this.Name = name;

            this.HealthMax = 80;
            this.HealthActual = 80;
            this.BaseAttackPower = 20;
            this.BaseDefensePower = 15;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new EternalStone();

            this.VictoryPoints = 0;
        }
    }
}