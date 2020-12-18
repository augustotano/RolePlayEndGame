using System;
using System.Collections.Generic;

namespace Classes
{
    public class Dragon : CharacterClass
    {
        public Dragon(string name = "Black Dragon")
        {
            this.Name = name;

            this.HealthMax = 200;
            this.HealthActual = 200;
            this.BaseAttackPower = 60;
            this.BaseDefensePower = 60;

            this.ItemList = new List<Items>();
            this.UnusableItems = new List<Items>();
            this.Registres = new ThousandYearTree();

            this.VictoryPoints = 5;
        }
    }
}