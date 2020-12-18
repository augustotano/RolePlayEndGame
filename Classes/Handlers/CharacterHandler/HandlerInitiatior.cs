using System;
using System.Collections.Generic;

namespace Classes
{
    public class HandlerInitiatior
    {
        public static List<Handler> InitiateHandlers()
        {
            OrcHandler orcHandler = new OrcHandler();
            
            WizardHandler wizardHandler = new WizardHandler();
            orcHandler.SetSucessor(wizardHandler);

            ChosenOneHandler chosenOneHandler = new ChosenOneHandler();
            wizardHandler.SetSucessor(chosenOneHandler);

            ElfHandler elfHandler = new ElfHandler();
            chosenOneHandler.SetSucessor(elfHandler);

            DwarfHandler dwarfHandler = new DwarfHandler();
            elfHandler.SetSucessor(dwarfHandler);

            DragonHandler dragonHandler = new DragonHandler();
            dwarfHandler.SetSucessor(dragonHandler);

            DemonHandler demonHandler = new DemonHandler();
            dragonHandler.SetSucessor(demonHandler);

            DarkLordHandler darkLordHandler = new DarkLordHandler();
            demonHandler.SetSucessor(darkLordHandler);

            DefaultHandler defaultHandler = new DefaultHandler();
            darkLordHandler.SetSucessor(default);
            
            List<Handler> list = new List<Handler>(){orcHandler,wizardHandler,chosenOneHandler,elfHandler,dwarfHandler,dragonHandler,demonHandler,darkLordHandler, default}; 

            return list;
        }
    }
}