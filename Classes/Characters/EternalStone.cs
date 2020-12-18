using System;

namespace Classes
{
    //Información extra en la clase abstracta.
    public class EternalStone : IHonorAndGlory
    {
        public int DefeatedEnemies {get; set;}

        public EternalStone()
        {
            this.DefeatedEnemies = 0;
        }

        public void Register(string data = "")
        {
            this.DefeatedEnemies++;
        }
        
        public string ShowRegistres()
        {
            return this.DefeatedEnemies.ToString();
        }
    }
}