using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    /*
    Con la clase CharacterClass, se trato de evitar lo más posible la acoplación, manteniendo
    la cohesión en el programa. Principalmente se trato de hacer mediante encapsulación de los datos.
    Por ejemplo, no hay un metodo atacar que recibe como parametro un CharacterClass y 
    que edita ese CharacterClass para inflingir daño. Lo que si hay es un metodo ReceiveAttack que
    recibe un Int que representa el daño, y un metodo Attack que devuelve ese Int.

    También se puede ver la creación de atributos como BaseAttack y BaseDefense que se trato
    que fuera diferente en cada subclase para darle un mayor sentimiento de variedad. Lo mismo
    paso con la vida máxima de todos los personajes.

    DIP: La gran mayoría de elementos dependen de abstracciones para evitar el acoplamiento.

    Polimorfismo: Los metodos ReceiveAttack y Attack son polimorficos, principalmente debido a la
    clase Wizard, que utiliza sus hechizos para atacar y defenderse. Pero en un futuro podrían
    recibir distintas implementaciones por nuevas clases con distintas mecanicas.

    Expert: CharacterClass es el experto en información cuando se trata de los items en el inventario,
    así como los atributos del personaje, por lo que los metodos ReceiveAttack y Attack estan en
    el lugar correcto. Lo mismo podría decirse de la mayoría de los metodos de esta clase.

    OCP: Pueden crearse nuevas clases a través de la implementación de CharacterClass sin necesidad
    de modificar el código existente. A su vez, pueden hacerse implementaciones especiales
    con los metodos polimorficos previamente mencionados. Todo esto agrega facilidades a la hora
    de extender el código.
    */
    public abstract class CharacterClass
    {
        public string Name {get; set;}
        public List<Items> ItemList {get; set;}
        public List<Items> UnusableItems {get; set;}

        public IHonorAndGlory Registres {get; set;}

        public int HealthMax {get; set;}
        public int HealthActual {get; set;}
        
        public int BaseAttackPower {get; set;}
        public int BaseDefensePower {get; set;}

        public int VictoryPoints {get; set;}

        public bool MagicalyEnabled {get; set;}


        public virtual void ReceiveDamage(int damage)
        {
            int defensePower = this.BaseDefensePower;
            IEnumerable<DefensiveItem> defensiveItems = this.ItemList.OfType<DefensiveItem>();
            IEnumerable<MixItem> mixItems = this.ItemList.OfType<MixItem>();

            foreach(DefensiveItem item in defensiveItems)
            {
                defensePower += item.DefensePower;
            }

            foreach(MixItem item in mixItems)
            {
                defensePower += item.DefensePower;
            }

            int actualDamage = damage - defensePower;

            if(actualDamage > 0)
            {
                this.HealthActual -= actualDamage;
                if(this.HealthActual > 0)
                {
                    Console.WriteLine($"{this.Name} has been damaged for {actualDamage} health points. {this.HealthActual} points still left until his death.");
                }
                else
                {
                    this.HealthActual = 0;
                    Console.WriteLine($"{this.Name} has died at the hands of the enemy.");
                }
                
            }
            else
            {
                Console.WriteLine("Despite the attack, not even a scratch as a result!");
            }
        }

        public virtual int Attack()
        {
            int attackPower = this.BaseAttackPower;
            IEnumerable<OffensiveItem> offensiveItems = this.ItemList.OfType<OffensiveItem>();
            IEnumerable<MixItem> mixItems = this.ItemList.OfType<MixItem>();

            foreach(OffensiveItem item in offensiveItems)
            {
                attackPower += item.AttackPower;
            }

            foreach(MixItem item in mixItems)
            {
                attackPower += item.AttackPower;
            }

            Console.WriteLine($"{this.Name} attacks with all his might. Attack Power: {attackPower}");

            return attackPower;
        }

        public void Healing(int heal)
        {
            int actualHealing = this.HealthActual + heal;

            if(actualHealing > this.HealthMax)
            {
                this.HealthActual = this.HealthMax;
            }
            else
            {
                this.HealthActual = actualHealing;
            }
        }

        public void AddVictoryPoints(int pointsEarned)
        {
            int actualVictoryPoints = this.VictoryPoints + pointsEarned;

            if(actualVictoryPoints >= 5)
            {
                this.Healing(this.HealthMax);
                this.VictoryPoints = 0;
            }
            else
            {
                this.VictoryPoints = actualVictoryPoints;
            }
        }

        public void AddItem(Items item)
        {
            if(item.Magical == true && MagicalyEnabled == false)
            {
                Console.WriteLine($"{this.Name} does not have the skill to make use of {item.Name}.");
                this.UnusableItems.Add(item);
            }
            else
            {
                this.ItemList.Add(item);
            }
        }
        
        public void RemoveItem(Items item)
        {
            bool removed = false;
            
            foreach(Items itemObtained in this.ItemList)
            {
                if(item.Name == itemObtained.Name)
                {
                    this.ItemList.Remove(itemObtained);
                    removed = true;
                    break;
                }
            }
            if(removed == false)
            {
                foreach(Items itemObtained in this.UnusableItems)
                {
                    if(item.Name == itemObtained.Name)
                    {
                        this.ItemList.Remove(itemObtained);
                        removed = true;
                        break;
                    }
                }

                if(removed == false)
                {
                    //Precondicion: que el booleano removed sea false
                    //Poscondición: se envia un mensaje por consola, informando de la excepcion.
                    //Invariantes: La lista de items se mantiene igual, el mensaje es el mismo.
                    throw new NoItemInInventoryException("You can't remove an item that you do not have.");
                }
            }
        }

        public void FuseItems (IFusionMaterial material1, IFusionMaterial material2)
        {
            foreach(Items item1 in this.ItemList)
            {
                if(material1.Check().Name == item1.Name)
                {
                    foreach(Items item2 in this.ItemList)
                    {
                        if(material2.Check().Name == item2.Name)
                        {
                            this.AddItem(material1.Fuse(material2));
                            this.RemoveItem(item2);
                            this.RemoveItem(item1);

                            Console.WriteLine($"Items fused succesfully. You've acquired {material1.Fuse(material2).Name}");
                            break;
                        }
                    }
                    break;
                }
            }

        }

        public void UseAsclepiosWand(AsclepiosWand wand, Items magicalItem)
        {
            foreach(AsclepiosWand item in this.ItemList)
            {
                if(item.Name == "Asclepio's Wand")
                {
                    foreach(Items unusuableItem in this.UnusableItems)
                    {
                        if(unusuableItem.Name == magicalItem.Name)
                        {
                            this.AddItem(item.CombineMagicalProperty(magicalItem));
                            this.RemoveItem(item);
                            this.RemoveItem(unusuableItem);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public bool IsDead()
        {
            if(this.HealthActual <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Register(string data)
        {
            this.Registres.Register(data);
        }
            

    }
}
