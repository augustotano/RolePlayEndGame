using System;
using System.Collections.Generic;

namespace Classes
{
    public class DarkSword : OffensiveItem
    {
        public List<Gem> Gems {get; set;}

        public DarkSword(Gem gem = null)
        {
            this.Name = "Demise";
            this.Magical = false;
            this.Gems = new List<Gem>();
            if(gem != null)
            {
                this.Gems.Add(gem);
            }
            this.AttackPower = 30*this.Gems.Count;
        }

        public void AddGem(Gem gem)
        {
            this.Gems.Add(gem);
            this.AttackPower += 30;
        }
    }
}