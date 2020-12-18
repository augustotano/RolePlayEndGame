using System;
using System.Collections.Generic;

namespace Classes
{
    /*
    El atributo estatico Results existe con el objetivo de poder editarlo desde
    los distintos encounters, para agregar la información que se crea necesaria.

    LSP: Se podría usar cualquier tipo de IPrinter e IScenarioReader y el programa funcionaría
    igual.
    */
    public class Scenario
    {
        public List<IEncounter> EncounterList {get; set;}
        public static List<string> Results {get; set;} 
        public List<List<CharacterClass>> HeroesAndVillains {get; set;}

        public Scenario()
        {
            this.EncounterList = new List<IEncounter>();
            this.HeroesAndVillains = new List<List<CharacterClass>>();
            Results = new List<string>();
        }

        public void PlayScenario()
        {
            foreach(IEncounter encounter in this.EncounterList)
            {
                List<List<CharacterClass>> aux = encounter.PlayEncounter();

                this.EliminateDead(aux);
            }
        }

        public void PrintResults(IPrinter printer)
        {
            if(this.HeroesAndVillains[0].Count > this.HeroesAndVillains[1].Count)
            {
                Results.Add($"\nThis time, the heroes have conquered the middle-earth, {this.HeroesAndVillains[0].Count} of them have survived.");
            }
            else if(this.HeroesAndVillains[0].Count < this.HeroesAndVillains[1].Count)
            {
                Results.Add($"\nThis time, villains have conquered the middle-earth, {this.HeroesAndVillains[1].Count} of them have survived.");
            }
            else
            {
                Results.Add("This time there are no winners in middle-earth. The eternal conflict continues.");
            }
            printer.Print(Results);
                
        }

        public void ReadScenario(IScenarioReader reader, string path)
        {
            this.HeroesAndVillains = reader.ReadCharacters(path);
            this.EncounterList = reader.ReadEncounters(path);
        }

        public void EliminateDead(List<List<CharacterClass>> encounterResults)
        {
            //Estos dos if y else if son a modo de asegurarse de que no haya problemas en un exchange encounter.
            //Como son entre personas del mismo bando, estan en una misma lista. Y si fueran de un bando distinto,
            //siempre y cuando se respete el orden de siempre (heroes 0 y villanos 1), el metodo funciona.
            if(this.HeroesAndVillains[0].Contains(encounterResults[0][0]) && this.HeroesAndVillains[0].Contains(encounterResults[1][0]))
            {
                this.HeroesAndVillains[0].AddRange(encounterResults[0]);
                this.HeroesAndVillains[0].AddRange(encounterResults[1]);
            }

            else if(this.HeroesAndVillains[1].Contains(encounterResults[0][0]) && this.HeroesAndVillains[1].Contains(encounterResults[1][0]))
            {
                this.HeroesAndVillains[1].AddRange(encounterResults[0]);
                this.HeroesAndVillains[1].AddRange(encounterResults[1]);
            }

            else
            {
                this.HeroesAndVillains[0].AddRange(encounterResults[0]);
                this.HeroesAndVillains[1].AddRange(encounterResults[1]);
            }

            List<CharacterClass> heroesList = new List<CharacterClass>();
            List<CharacterClass> villainsList = new List<CharacterClass>();
            List<List<CharacterClass>> heroesAndVillains2 = new List<List<CharacterClass>>(){heroesList,villainsList};
            heroesAndVillains2.AddRange(this.HeroesAndVillains);

            foreach(CharacterClass hero in heroesAndVillains2[0])
            {
                if(hero.HealthActual < 0)
                {
                    this.HeroesAndVillains[0].Remove(hero);
                    this.HeroesAndVillains[0].Remove(hero);
                }
                else
                {
                    this.HeroesAndVillains[0].Remove(hero);
                }
            }

            foreach(CharacterClass villain in heroesAndVillains2[1])
            {
                if(villain.HealthActual < 0)
                {
                    this.HeroesAndVillains[0].Remove(villain);
                    this.HeroesAndVillains[0].Remove(villain);
                }
                else
                {
                    this.HeroesAndVillains[0].Remove(villain);
                }
            }
        }
    }
}