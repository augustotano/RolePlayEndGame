using System;

namespace Classes
{
    public class DwarfHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "DWARF")
            {
                return new Dwarf();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}