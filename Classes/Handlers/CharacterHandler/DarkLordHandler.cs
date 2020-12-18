using System;

namespace Classes
{
    public class DarkLordHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "DARKLORD")
            {
                return new DarkLord();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}