using System;

namespace Classes
{
    public class ElfHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "ELF")
            {
                return new Elf();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}