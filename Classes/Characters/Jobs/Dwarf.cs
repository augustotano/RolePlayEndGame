using System;
using System.Collections.Generic;

namespace Classes
{
    public class Dwarf : CharacterClass
    {
        public Dwarf(string name = "Dwarf")
        {
            this.Name = name;

            this.HealthMax = 100;
            this.HealthActual = 100;
            this.BaseAttackPower = 18;
            this.BaseDefensePower = 20;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new EternalStone();

            this.VictoryPoints = 0;
        }
    }
}