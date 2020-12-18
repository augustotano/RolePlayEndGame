using System;
using System.Collections.Generic;
using Classes;

namespace PII_EXAMEN_ROLEPLAY_ENDGAME
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FilePrinter printer = new FilePrinter();
            CSVScenarioReader reader = new CSVScenarioReader();

            reader.AddHandlerList(HandlerInitiatior.InitiateHandlers());

            Scenario scenario = new Scenario();

            scenario.ReadScenario(reader, @"..\Config\ConfigurationFile.txt");

            scenario.PlayScenario();

            scenario.PrintResults(printer);
            
        }
    }
}
