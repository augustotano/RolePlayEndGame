using NUnit.Framework;
using Classes;
using System.Collections.Generic;

namespace tests
{
    public class ItemTest
    {
        [SetUp]
        public void Setup()
        {
        }

        //Normalmente, los items mágicos no se agregan a la ItemList. Esto no es así en el caso de los Wizards.
        [Test]
        public void WizardsCanUseMagicalItemsTest()
        {
            Wizard gandalf = new Wizard();

            Excalibur excalibur = new Excalibur();

            gandalf.AddItem(excalibur);

            Assert.AreEqual(1, gandalf.ItemList.Count);
        }

        //Se comprueba que en el caso de no magos, van a UnusableItems
        [Test]
        public void NonWizardCantUseMagicalItemsTest()
        {
            Dwarf gimli = new Dwarf();

            Excalibur sword = new Excalibur();

            gimli.AddItem(sword);

            Assert.AreEqual(0, gimli.ItemList.Count);
        }

        [Test]
        public void AsclepiosWandTest()
        {
            AsclepiosWand wand = new AsclepiosWand();
            Excalibur sword = new Excalibur();
            Dwarf gimli = new Dwarf();

            gimli.AddItem(wand);
            gimli.AddItem(sword);

            gimli.UseAsclepiosWand(wand, sword);

            Assert.AreEqual(1, gimli.ItemList.Count);
        }

        [Test]
        public void DarkSwordTest()
        {
            Gem gem1 = new Gem("Fire Gem");
            Gem gem2 = new Gem("Earth Gem");
            DarkSword sword = new DarkSword();
            Dwarf gimli = new Dwarf();
            Orc dummy1 = new Orc();
            Orc dummy2 = new Orc();
            Orc dummy3 = new Orc();

            gimli.AddItem(sword);
            dummy1.ReceiveDamage(gimli.Attack());

            sword.AddGem(gem1);
            dummy2.ReceiveDamage(gimli.Attack());

            sword.AddGem(gem2);
            dummy3.ReceiveDamage(gimli.Attack());

            Assert.IsTrue(dummy3.HealthActual < dummy2.HealthActual && dummy2.HealthActual < dummy1.HealthActual);
        }

        //Se comprueba que la fusion se logra correctamente al quedar solo un item en la lista de items de gimli.
        [Test]
        public void ItemCombinationTest()
        {
            Dwarf gimli = new Dwarf();
            StygianBlade blade = new StygianBlade();
            FrostMourne sword = new FrostMourne();

            gimli.AddItem(blade);
            gimli.AddItem(sword);

            gimli.FuseItems(blade,sword);

            Assert.AreEqual(1,gimli.ItemList.Count);
        }
    }
}   