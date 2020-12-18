using System;
using System.IO;
using System.Collections.Generic;

namespace Classes
{
    /*
    Mayor información en la clase abstracta.
    */
    public class CSVScenarioReader : IScenarioReader
    {
        List<Handler> HandlerList {get; set;}
        Dictionary<string, CharacterClass> CharacterDictionary{get; set;}
        public CSVScenarioReader()
        {
            this.HandlerList = new List<Handler>();
            this.CharacterDictionary = new Dictionary<string, CharacterClass>();
        }
        public List<IEncounter> ReadEncounters(string path)
        {
            List<IEncounter> list = new List<IEncounter>();
            StreamReader reader = new StreamReader(path);
            string line;
            string[] separationBetweenCharactersAndEncounters;
            string[] eachEncounter;

            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                separationBetweenCharactersAndEncounters = line.Split("-");
                eachEncounter = separationBetweenCharactersAndEncounters[1].Split(";");

                foreach(string element in eachEncounter)
                {
                    string[] encounterType = element.Split(":");

                    if(encounterType[0].ToUpper() == "BATTLEENCOUNTER" || encounterType[0].ToUpper() == "BATTLE ENCOUNTER")
                    {
                        string[] eachCharacterBand = encounterType[1].Split("_");
                        string[] everyHero = eachCharacterBand[0].Split(",");
                        string[] everyVillain = eachCharacterBand[1].Split(",");

                        List<CharacterClass> heroes = new List<CharacterClass>();
                        List<CharacterClass> villains = new List<CharacterClass>();

                        foreach(string hero in everyHero)
                        {
                            heroes.Add(this.CharacterDictionary.GetValueOrDefault(hero));
                        } 
                        foreach(string villain in everyVillain)
                        {
                            villains.Add(this.CharacterDictionary.GetValueOrDefault(villain));
                        }

                        list.Add(new BattleEncounter(heroes, villains));
                    }
                    else if(encounterType[0].ToUpper() == "EXCHANGEENCOUNTER" || encounterType[0].ToUpper() == "EXCHANGE ENCOUNTER")
                    {
                        string[] eachCharacterBand = encounterType[1].Split(",");
                        list.Add(new ExchangeEncounter(this.CharacterDictionary.GetValueOrDefault(eachCharacterBand[0]),this.CharacterDictionary.GetValueOrDefault(eachCharacterBand[1]),eachCharacterBand[2]));
                    }
                }
                break;
            }
            return list;
        }

        public List<List<CharacterClass>> ReadCharacters(string path)
        {
            List<CharacterClass> subList = new List<CharacterClass>();
            List<CharacterClass> subList2 = new List<CharacterClass>();
            List<List<CharacterClass>> list = new List<List<CharacterClass>>(){subList,subList2};
            StreamReader reader = new StreamReader(path);
            string line;
            string[] separationBetweenCharactersAndEncounters;
            string[] data;
            string[] heroData;
            string[] villainData;

            int counter = 0;
            int indexCounter = 0;

            while(!reader.EndOfStream)
            {
                line = reader.ReadLine();
                separationBetweenCharactersAndEncounters = line.Split("-");
                data = separationBetweenCharactersAndEncounters[0].Split(";");
                heroData = data[0].Split(",");
                villainData = data[1].Split(",");

                foreach(string item in heroData)
                {
                    list[0].Add(this.HandlerList[0].HandleRequest(item));
                    this.CharacterDictionary.Add(counter.ToString(), list[0][indexCounter]);
                    counter++;
                    indexCounter++;
                }

                indexCounter = 0;
                foreach(string item in villainData)
                {
                    list[1].Add(this.HandlerList[0].HandleRequest(item));
                    this.CharacterDictionary.Add(counter.ToString(), list[1][indexCounter]);
                    counter++;
                    indexCounter++;
                }
                break;
            }

            return list;
        }

        public void AddHandlerList(List<Handler> list)
        {
            this.HandlerList = list;
        }
    }
}
