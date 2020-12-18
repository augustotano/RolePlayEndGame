using System;
using System.Collections.Generic;

namespace Classes
{
    //Información extra en la clase abstracta.
    public class BookOfWisdom : IHonorAndGlory
    {
        public List<string> WhoSlayedWho {get; set;}

        public BookOfWisdom()
        {
            this.WhoSlayedWho = new List<string>();
        }

        public void Register(string data = "")
        {
            this.WhoSlayedWho.Add(data);
        }

        public string ShowRegistres()
        {
            string theOneString = "";
            foreach(string line in this.WhoSlayedWho)
            {
                theOneString += line;
            }
            return theOneString;
        }
    }
}