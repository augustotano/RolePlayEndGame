using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
    /*
    Expert: Spell-Book es el experto en información sobre Spells, ya que conoce todas las que el 
    mago puede utilizar, es natural que sea a través de Spell-Book que se utilice una spell.
    */
    public class SpellBook : Items
    {
        List<Spell> SpellList {get; set;}

        public SpellBook(string name = "Spell-book")
        {
            this.Name = name;
            this.Magical = true;
            List<Spell> SpellList = new List<Spell> ();
        }

        public void AddSpell(Spell spell)
        {
            this.SpellList.Add(spell);
        }

        public void RemoveSpell (Spell spell)
        {
            if(this.SpellList.Contains(spell))
            {
                this.SpellList.Remove(spell);
            }
        }

        public int UseAttackSpell ()
        {
            try
            {
                IEnumerable<AttackSpell> attackSpellList = this.SpellList.OfType<AttackSpell>();
                List<int> indexList = new List<int>();

                foreach(AttackSpell attackSpell in attackSpellList)
                {
                    foreach(Spell spell in this.SpellList)
                    {
                        if(attackSpell.Name == spell.Name)
                        {
                            indexList.Add(this.SpellList.IndexOf(spell));
                        }
                    }
                }

                List<Spell> trueAttackSpellList = new List<Spell>();
                foreach(int number in indexList)
                {
                    trueAttackSpellList.Add(this.SpellList[number]);
                }

                if(trueAttackSpellList.Count == 0)
                {
                    Console.WriteLine("There are no attack spells available.");
                    return 0;
                }
                else
                {
                    Random rnd = new Random();

                    return trueAttackSpellList[rnd.Next(0,trueAttackSpellList.Count)].UseSpell();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int UseDefenseSpell ()
        {
            try
            {
                IEnumerable<DefenseSpell> defenseSpellList = this.SpellList.OfType<DefenseSpell>();
                List<int> indexList = new List<int>();

                foreach(DefenseSpell defenseSpell in defenseSpellList)
                {
                    foreach(Spell spell in this.SpellList)
                    {
                        if(defenseSpell.Name == spell.Name)
                        {
                            indexList.Add(this.SpellList.IndexOf(spell));
                        }
                    }
                }

                List<Spell> trueDefenseSpellList = new List<Spell>();
                foreach(int number in indexList)
                {
                    trueDefenseSpellList.Add(this.SpellList[number]);
                }

                if(trueDefenseSpellList.Count == 0)
                {
                    Console.WriteLine("There are no defense spells available.");
                    return 0;
                }
                else
                {
                    Random rnd = new Random();

                    return trueDefenseSpellList[rnd.Next(0,trueDefenseSpellList.Count)].UseSpell();
                }
            }
            catch
            {
                return 0;
            }
        }


        public int UseHealingSpell ()
        {
            try
            {
                IEnumerable<HealingSpell> healingSpellList = this.SpellList.OfType<HealingSpell>();
                List<int> indexList = new List<int>();

                foreach(HealingSpell healingSpell in healingSpellList)
                {
                    foreach(Spell spell in this.SpellList)
                    {
                        if(healingSpell.Name == spell.Name)
                        {
                            indexList.Add(this.SpellList.IndexOf(spell));
                        }
                    }
                }

                List<Spell> trueHealingSpellList = new List<Spell>();
                foreach(int number in indexList)
                {
                    trueHealingSpellList.Add(this.SpellList[number]);
                }

                if(trueHealingSpellList.Count == 0)
                {
                    Console.WriteLine("There are no healing spells available.");
                    return 0;
                }
                else
                {
                    Random rnd = new Random();

                    return trueHealingSpellList[rnd.Next(0,trueHealingSpellList.Count)].UseSpell();
                }
            }
            catch
            {
                return 0;
            }
        }


    }
}