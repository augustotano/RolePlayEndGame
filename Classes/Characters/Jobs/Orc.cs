using System;
using System.Collections.Generic;

namespace Classes
{
    public class Orc : CharacterClass
    {
        public Orc(string name = "Orc")
        {
            this.Name = name;

            this.HealthMax = 100;
            this.HealthActual = 100;
            this.BaseAttackPower = 5;
            this.BaseDefensePower = 5;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new ThousandYearTree();

            this.VictoryPoints = 1;
        }
    }
}