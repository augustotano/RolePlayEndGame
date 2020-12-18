using System;

namespace Classes
{
    public class OrcHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "ORC")
            {
                return new Orc();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}