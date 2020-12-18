using System;

namespace Classes
{
    public class DemonHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "DEMON")
            {
                return new Demon();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}