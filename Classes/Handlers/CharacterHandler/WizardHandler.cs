using System;

namespace Classes
{
    public class WizardHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            if(data.ToUpper() == "WIZARD")
            {
                return new Wizard();
            }
            else
            {
                return this.succesor.HandleRequest(data);
            }
        }
    }
}