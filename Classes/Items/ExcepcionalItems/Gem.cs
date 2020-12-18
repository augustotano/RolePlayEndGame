using System;

namespace Classes
{
    public class Gem : Items
    {
        public Gem(string name)
        {
            this.Name = name;
            this.Magical = false;
        }
    }
}