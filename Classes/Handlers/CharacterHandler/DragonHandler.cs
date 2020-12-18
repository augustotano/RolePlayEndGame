using System;

namespace Classes
{
    public class DragonHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "DRAGON")
            {
                return new Dragon();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}