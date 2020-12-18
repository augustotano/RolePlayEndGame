using System;

namespace Classes
{
    public class ChosenOneHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "CHOSENONE")
            {
                return new ChosenOne();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}