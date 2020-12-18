using System;
using System.Collections.Generic;

namespace Classes
{
    public class DarkLord : CharacterClass
    {
        public DarkLord(string name = "Sauron")
        {
            this.Name = name;

            this.HealthMax = 125;
            this.HealthActual = 125;
            this.BaseAttackPower = 70;
            this.BaseDefensePower = 70;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new ThousandYearTree();

            this.VictoryPoints = 5;
        }
    }
}