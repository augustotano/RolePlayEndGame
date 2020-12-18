using System;
using System.Collections.Generic;

namespace Classes
{
    //Información extra en la clase abstracta.
    public class ThousandYearTree : IHonorAndGlory
    {
        public List<string> EnemiesDefeated {get; set;}

        public ThousandYearTree()
        {
            this.EnemiesDefeated = new List<string>();
        }

        public void Register(string data = "")
        {
            this.EnemiesDefeated.Add(data);
        }

        public string ShowRegistres()
        {
            string theOneString = "";
            foreach(string line in this.EnemiesDefeated)
            {
                theOneString += line;
            }
            return theOneString;
        }

    }
        
}