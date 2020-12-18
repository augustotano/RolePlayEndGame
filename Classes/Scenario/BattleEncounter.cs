using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    /*
    Mayor información en la interfaz.
    */
    public class BattleEncounter : IEncounter
    {
        public List<CharacterClass> Heroes {get; set;}
        public List<CharacterClass> Villains {get; set;}

        public BattleEncounter(List<CharacterClass> heroes, List<CharacterClass> villains)
        {
            this.Heroes = heroes;
            this.Villains = villains;

            try
            {
                IEnumerable<Wizard> wizards = this.Heroes.OfType<Wizard>();
            }
            catch
            {
                Wizard pseudoWizard = new Wizard();
                pseudoWizard.HealthActual = 0;
            }
        }

        public List<List<CharacterClass>> PlayEncounter()
        {   
            string recountString = "";
            List<CharacterClass> returnableSubList0 = new List<CharacterClass>();
            List<CharacterClass> returnableSubList1 = new List<CharacterClass>();
            List<List<CharacterClass>> returnableList = new List<List<CharacterClass>>(){returnableSubList0, returnableSubList1};


            //Para el index es utilizado para poder hacer el registro de los magos cada vez que muere alguien.
            List<int> wizardIndex = new List<int>();
            IEnumerable<Wizard> wizards = this.Heroes.OfType<Wizard>();

            foreach(CharacterClass heroe in this.Heroes)
            {
                foreach(Wizard wizard in wizards)
                {
                    if(wizard.Name == heroe.Name)
                    {
                        wizardIndex.Add(this.Heroes.IndexOf(heroe));
                    }
                }
            }

            //Loop que se repite mientras no esten todos muertos en alguna de las listas (heroes o villanos)
            while(!this.EveryoneDead(this.Heroes) && !this.EveryoneDead(this.Villains))
            {
                //aux sirve para controlar el indice de los atacados.
                int aux = 0;
                for(int i = 0; i < this.Villains.Count; i++)
                {
                    if(this.Heroes[aux].IsDead())
                    {
                        //Chequea cada vez que encuentra un persona muerto para evitar bucles infinitos.
                        if(this.EveryoneDead(this.Heroes))
                        {
                            break;
                        }
                        else if(aux < this.Heroes.Count-1)
                        {
                            aux++;
                        }
                        else
                        {
                            aux = 0;
                        }
                    }
                    //Chequea que el villano este vivo antes de que ataque.
                    if(this.Villains[i].HealthActual>0)
                    {
                        this.Heroes[aux].ReceiveDamage(this.Villains[i].Attack());

                        if(this.Heroes[aux].IsDead())
                        {
                            this.Villains[i].Register(this.Heroes[aux].Name);
                            foreach(int index in wizardIndex)
                            {
                                this.Heroes[index].Register($"{this.Heroes[aux].Name} has been slain by {this.Villains[i].Name}");
                            }
                            recountString += $"{this.Heroes[aux].Name} has been slain by {this.Villains[i].Name},";                            
                        }
                        if(aux < this.Heroes.Count-1)
                        {
                            aux++;
                        }
                        else
                        {
                            aux = 0;
                        }
                    }
                }

                aux = 0;
                for(int i = 0; i < this.Heroes.Count; i++)
                {
                    if(this.Villains[aux].IsDead())
                    {
                        //Chequea cada vez que encuentra un personaje muerto para evitar bucle infinito.
                        if(this.EveryoneDead(this.Villains))
                        {
                            break;
                        }
                        else if(aux < this.Villains.Count-1)
                        {
                            aux++;
                        }
                        else
                        {
                            aux = 0;
                        }
                    }
                    if(this.Heroes[i].HealthActual>0)
                    {
                        this.Villains[aux].ReceiveDamage(this.Heroes[i].Attack());
                        
                        if(this.Villains[aux].IsDead())
                        {
                            this.Heroes[i].Register("-");
                            this.Heroes[i].AddVictoryPoints(this.Villains[aux].VictoryPoints);
                            foreach(int index in wizardIndex)
                            {
                                this.Heroes[index].Register($"{this.Villains[aux].Name} has been slain by {this.Heroes[i].Name}");
                            }
                            recountString += $"{this.Villains[aux].Name} has been slain by {this.Heroes[i].Name},";
                        }
                        if(aux < this.Villains.Count-1)
                        {
                            aux++;
                        }
                        else
                        {
                            aux = 0;
                        }
                    }
                }
            }

            Scenario.Results.Add(recountString+";");
            
            if(this.EveryoneDead(this.Heroes))
            {
                Scenario.Results.Add("The Villains have won this encounter. \n");
            }
            else
            {
                Scenario.Results.Add("The Heroes have won this encounter.\n");
            }
            
            returnableList[0] = this.Heroes;
            returnableList[1] = this.Villains;
            
            return returnableList;
        }

        public bool EveryoneDead(List<CharacterClass> list)
        {
            bool everyoneDead = true;

            foreach(CharacterClass character in list)
            {
                if(character.HealthActual > 0)
                {
                    everyoneDead = false;
                }
            }
                
            return everyoneDead;
        }

    }
}