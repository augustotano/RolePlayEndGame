using System;
using System.Collections.Generic;

namespace Classes
{
    public class Demon : CharacterClass
    {
        public Demon(string name = "Balrog")
        {
            this.Name = name;

            this.HealthMax = 125;
            this.HealthActual = 125;
            this.BaseAttackPower = 25;
            this.BaseDefensePower = 25;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new ThousandYearTree();

            this.VictoryPoints = 2;
        }
    }
}