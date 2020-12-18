using NUnit.Framework;
using Classes;
using System.Collections.Generic;

namespace tests
{
    public class EncounterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Se comprueba que un persona gana el item y el otro lo pierde.
        [Test]
        public void ExchangeEncounterTest()
        {
            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            BasicSword sword = new BasicSword();

            gimli.AddItem(sword);

            ExchangeEncounter encounter = new ExchangeEncounter(gimli, legolas, sword.Name);

            Assert.AreEqual(1, encounter.PlayEncounter()[1][0].ItemList.Count); 
        }

        //PlayEncounter()[1][0] refiere al receiver de los objetos.
        [Test]
        public void ManyItemsExchangeEncounterTest()
        {
            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            BasicSword sword = new BasicSword();
            StygianBlade blade = new StygianBlade();
            HearthSeekingBow bow = new HearthSeekingBow();

            gimli.AddItem(sword);
            gimli.AddItem(blade);
            gimli.AddItem(bow);

            List<string> itemList = new List<string>(){sword.Name, blade.Name, bow.Name};

            ExchangeEncounter encounter = new ExchangeEncounter(gimli, legolas, itemList);

            Assert.AreEqual(3, encounter.PlayEncounter()[1][0].ItemList.Count);          
        }

        [Test]
        public void NotEnoughItemsExchangeEncounterTest()
        {
            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            BasicSword sword = new BasicSword();
            StygianBlade blade = new StygianBlade();
            HearthSeekingBow bow = new HearthSeekingBow();

            gimli.AddItem(blade);
            gimli.AddItem(bow);

            List<string> itemList = new List<string>(){sword.Name, blade.Name, bow.Name};
            ExchangeEncounter encounter = new ExchangeEncounter(gimli, legolas, itemList);
            try
            {
                encounter.PlayEncounter();
                Assert.Fail();
            }
            //Si hay una excepción al tratar de intercambiar un item que no se tiene, se pasa al bloque catch y por ende se cumple el test.
            catch
            {
                Assert.Pass();
            }
        }

        [Test]
        public void NoItemForExchangeEncounterTest()
        {
            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            BasicSword sword = new BasicSword();

            try
            {
                ExchangeEncounter encounter = new ExchangeEncounter(gimli, legolas, sword.Name);
                encounter.PlayEncounter();
                Assert.Fail();
            }
            //Si hay una excepción al tratar de intercambiar un item que no se tiene, se pasa al bloque catch y por ende se cumple el test.
            catch
            {
                Assert.Pass();
            }
        }
        //El enano debería ganar puesto que tiene mejores estadisticas base.
        //everything[1][0] (1 hace referencia a los villanos, 0 al primer y único villano)
        [Test]
        public void BattleEncounterNoWeaponsTest()
        {
            Scenario scenario = new Scenario();
            Dwarf gimli = new Dwarf();
            Orc orc = new Orc();

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli};
            List<CharacterClass> villains = new List<CharacterClass>(){orc};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.AreEqual(0, everything[1][0].HealthActual);
        }

        //El enano debería perder puesto que el orco tiene una cantidad gigante de armadura.
        //everything[0][0] (0 hace referencia a los heroes, 0 al primer y único heroe)
        [Test]
        public void BattleEncounterWithArmorAndWeaponsTest()
        {
            Scenario scenario = new Scenario();
            Dwarf gimli = new Dwarf();
            Orc orc = new Orc();
            
            BasicSword sword = new BasicSword();
            ChainMail armor = new ChainMail();
            GoldenCoat coat = new GoldenCoat();

            orc.AddItem(sword);
            orc.AddItem(armor);
            orc.AddItem(coat);

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli};
            List<CharacterClass> villains = new List<CharacterClass>(){orc};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.AreEqual(0, everything[0][0].HealthActual);
        }

        //Heroes tienen mejores estadisticas basicas que orcos comunes, así que ganan si o si.
        //Al sumar la vida de todos, demostramos que ese bando murio.
        [Test]
        public void BattleEncounterEndsWhenEveryoneOnOneSideDiesTest()
        {
            Scenario scenario = new Scenario();

            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            ChosenOne aragorn = new ChosenOne();
            Wizard gandalf = new Wizard();

            Orc orc = new Orc();
            Orc orc2 = new Orc();
            Orc orc3 = new Orc();
            Orc orc4 = new Orc();

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli, legolas, aragorn, gandalf};
            List<CharacterClass> villains = new List<CharacterClass>(){orc, orc2, orc3, orc4};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.AreEqual(0, everything[1][0].HealthActual+everything[1][1].HealthActual+everything[1][2].HealthActual+everything[1][3].HealthActual);
        }

        //De igual manera, los heroes no pueden sin equipo contra cuatro señores oscuros.
        //Esta vez, se comprueba mediante el metodo interno de Encounter EveryoneDead()
        [Test]
        public void BattleEncounterEndsWhenEveryoneOnOneSideDiesPart2Test()
        {
            Scenario scenario = new Scenario();

            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            ChosenOne aragorn = new ChosenOne();
            Wizard gandalf = new Wizard();

            DarkLord orc = new DarkLord();
            DarkLord orc2 = new DarkLord();
            DarkLord orc3 = new DarkLord();
            DarkLord orc4 = new DarkLord();

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli, legolas, aragorn, gandalf};
            List<CharacterClass> villains = new List<CharacterClass>(){orc, orc2, orc3, orc4};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.IsTrue(battle.EveryoneDead(everything[0]));
        }

        [Test]
        public void WhatIfThereAreLessEnemiesThanHeroesTest()
        {
            Scenario scenario = new Scenario();

            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            ChosenOne aragorn = new ChosenOne();
            Wizard gandalf = new Wizard();

            Orc orc = new Orc();
            Orc orc2 = new Orc();
            Orc orc3 = new Orc();

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli, legolas, aragorn, gandalf};
            List<CharacterClass> villains = new List<CharacterClass>(){orc, orc2, orc3};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.IsTrue(battle.EveryoneDead(everything[1]));
        }

        [Test]
        public void WhatIfThereAreMoreEnemiesThanHeroes()
        {
            Scenario scenario = new Scenario();

            Dwarf gimli = new Dwarf();
            Elf legolas = new Elf();
            ChosenOne aragorn = new ChosenOne();
            Wizard gandalf = new Wizard();

            Orc orc = new Orc();
            Orc orc2 = new Orc();
            Orc orc3 = new Orc();
            Orc orc4 = new Orc();
            Orc orc5 = new Orc();

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli, legolas, aragorn, gandalf};
            List<CharacterClass> villains = new List<CharacterClass>(){orc, orc2, orc3, orc4, orc5};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.IsTrue(battle.EveryoneDead(everything[1]));
        }
        
        //La piedra eterna aumenta en 1 por cada enemigo derrotado. Al derrotar a un enemigo, su valor debería ser uno.
        [Test]
        public void EternalStoneWorksForHeroes()
        {
            Scenario scenario = new Scenario();
            Dwarf gimli = new Dwarf();
            Orc orc = new Orc();

            List<CharacterClass> heroes = new List<CharacterClass>(){gimli};
            List<CharacterClass> villains = new List<CharacterClass>(){orc};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.AreEqual("1", gimli.Registres.ShowRegistres());
        }

        //El libro de la sabiduría crea una frase cada vez que muere un personaje, ya sea aliado o enemigo y describe quien lo mató.
        //everything[0][0] representa a gandalf despues del encuentro, mientras que everything[1][0] al orco.
        [Test]
        public void BookOfWisdomWorksForWizards()
        {
            Scenario scenario = new Scenario();
            Wizard gandalf = new Wizard();
            Orc orc = new Orc();

            Excalibur sword = new Excalibur();
            gandalf.AddItem(sword);

            List<CharacterClass> heroes = new List<CharacterClass>(){gandalf};
            List<CharacterClass> villains = new List<CharacterClass>(){orc};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.AreEqual($"-{everything[1][0].Name} has been slain by {everything[0][0].Name}", everything[0][0].Registres.ShowRegistres());
        }

        //Finalmente, el arbol de los mil años, donde nos enemigos anotan a que heroe derrotaron.
        [Test]
        public void ThousandYearTreeTest()
        {
            Scenario scenario = new Scenario();
            Dwarf gimli = new Dwarf();
            Dragon dragon = new Dragon();


            List<CharacterClass> heroes = new List<CharacterClass>(){gimli};
            List<CharacterClass> villains = new List<CharacterClass>(){dragon};

            BattleEncounter battle = new BattleEncounter(heroes, villains);
            
            List<List<CharacterClass>> everything = battle.PlayEncounter();

            Assert.AreEqual(gimli.Name, everything[1][0].Registres.ShowRegistres());
        }
    }
}   