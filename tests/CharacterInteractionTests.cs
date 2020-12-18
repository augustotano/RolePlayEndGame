using NUnit.Framework;
using Classes;

namespace tests
{
    public class CharacterInteractionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GimliDeadTest()
        {
            Dwarf gimli = new Dwarf();
            gimli.ReceiveDamage(1000);
            Assert.IsTrue(gimli.IsDead());
        }

        [Test]
        public void GimliAliveTest()
        {
            Dwarf gimli = new Dwarf();
            gimli.Healing(1000);
            Assert.IsFalse(gimli.IsDead());
        }

        //Comprueba que el poder de ataque aumente a través del daño inflingido.
        [Test]
        public void PuttingAttackItemInTest()
        {
            Dwarf gimli = new Dwarf();
            Orc dummy1 = new Orc();

            dummy1.ReceiveDamage(gimli.Attack());

            Orc dummy2 = new Orc();
            BasicSword sword = new BasicSword();
            gimli.AddItem(sword);

            dummy2.ReceiveDamage(gimli.Attack());

            Assert.AreEqual(dummy1.HealthActual - dummy2.HealthActual, sword.AttackPower);
        }

        //Comprueba que aumente la defensa a través del daño recibido.
        [Test]
        public void PuttingDefenseItemInTest()
        {
            Dwarf gimli = new Dwarf();
            Dragon dummy = new Dragon();

            gimli.ReceiveDamage(dummy.Attack());
            int checkPoint1 = gimli.HealthMax - gimli.HealthActual;

            gimli.Healing(1000);
            ChainMail armor = new ChainMail();
            gimli.AddItem(armor);

            gimli.ReceiveDamage(dummy.Attack());
            int checkPoint2 = gimli.HealthMax - gimli.HealthActual;

            Assert.AreEqual(checkPoint1 - checkPoint2, armor.DefensePower);
        }

        //Comprueba que el ataque haya disminuido a través del daño inflingido.
        [Test]
        public void TakingAttackItemOutTest()
        {
            Dwarf gimli = new Dwarf();
            Orc dummy1 = new Orc();
            BasicSword sword = new BasicSword();
            gimli.AddItem(sword);

            dummy1.ReceiveDamage(gimli.Attack());

            Orc dummy2 = new Orc();
            gimli.RemoveItem(sword);

            dummy2.ReceiveDamage(gimli.Attack());

            Assert.AreEqual(dummy2.HealthActual - dummy1.HealthActual, sword.AttackPower);
        }

        //Comprueba que la defensa haya disminuido a través del daño recibido.
        [Test]
        public void TakingDefenseItemOutTest()
        {
            Dwarf gimli = new Dwarf();
            Dragon dummy = new Dragon();
            ChainMail armor = new ChainMail();
            gimli.AddItem(armor);

            gimli.ReceiveDamage(dummy.Attack());
            int checkPoint1 = gimli.HealthMax - gimli.HealthActual;

            gimli.RemoveItem(armor);
            gimli.Healing(1000);

            gimli.ReceiveDamage(dummy.Attack());
            int checkPoint2 = gimli.HealthMax - gimli.HealthActual;

            Assert.AreEqual(checkPoint2 - checkPoint1, armor.DefensePower);
        }

        //Comprueba que el poder de ataque aumente a través del daño inflingido.
        [Test]
        public void TwoAttackItemsTest()
        {
            Dwarf gimli = new Dwarf();
            Orc dummy1 = new Orc();

            dummy1.ReceiveDamage(gimli.Attack());

            Orc dummy2 = new Orc();
            BasicSword sword = new BasicSword();
            StygianBlade sword2 = new StygianBlade();

            gimli.AddItem(sword);
            gimli.AddItem(sword2);

            dummy2.ReceiveDamage(gimli.Attack());

            Assert.AreEqual(dummy1.HealthActual - dummy2.HealthActual, sword.AttackPower + sword2.AttackPower);
        }

        //Comprueba que aumente la defensa a través del daño recibido.
        [Test]
        public void TwoDefenseItemsTest()
        {
            Dwarf gimli = new Dwarf();
            Dragon dummy = new Dragon();

            gimli.ReceiveDamage(dummy.Attack());
            int checkPoint1 = gimli.HealthMax - gimli.HealthActual;

            gimli.Healing(1000);
            ChainMail armor = new ChainMail();
            GoldenCoat coat = new GoldenCoat();
            gimli.AddItem(armor);
            gimli.AddItem(coat);

            gimli.ReceiveDamage(dummy.Attack());
            int checkPoint2 = gimli.HealthMax - gimli.HealthActual;

            Assert.AreEqual(checkPoint1 - checkPoint2, armor.DefensePower + coat.DefensePower);
        }

        [Test]
        public void RemoveAnItemThatYouDoNotHaveTest()
        {
            Dwarf gimli = new Dwarf();
            BasicSword sword = new BasicSword();

            try
            {
                gimli.RemoveItem(sword);
                Assert.Fail();
            }
            //Si hay una excepción al tratar de remover un item que no se tiene, se pasa el test.
            catch
            {
                Assert.Pass();
            }
        }

        //Test que compara el daño recibido con el poder de ataque del atacante menos la defensa del defensor.
        [Test]
        public void HealthReductedTest()
        {
            Dwarf gimli = new Dwarf();
            StygianBlade sword = new StygianBlade();
            Orc dummy = new Orc();
            GoldenCoat coat = new GoldenCoat();

            gimli.AddItem(sword);
            dummy.AddItem(coat);

            dummy.ReceiveDamage(gimli.Attack());

            Assert.AreEqual(dummy.HealthMax-dummy.HealthActual, gimli.BaseAttackPower+sword.AttackPower-dummy.BaseDefensePower-coat.DefensePower);
        }

        //Prueba que la vida actual nunca puede ser menor a 0.
        [Test]
        public void DamageReceivedTest()
        {
            Dwarf gimli = new Dwarf();

            gimli.ReceiveDamage(gimli.HealthMax+10000);

            Assert.AreEqual(gimli.HealthActual, 0);
        }        

        //Ataque base del orco es 5, defensa del enano es 20, el orco no hace daño.
        [Test]
        public void AttackLessThanDefense()
        {
            Orc dummy = new Orc();
            Dwarf gimli = new Dwarf();

            gimli.ReceiveDamage(dummy.Attack());

            Assert.AreEqual(gimli.HealthMax, gimli.HealthActual);
        }

        //DarkLord no puede matar a un enano super equipado, pero si dañarlo.
        //Sin embargo, al morir, el DarkLord da 5 puntos de victoria, lo que cura a gimli.
        [Test]
        public void VictoryPointsTest()
        {
            Dwarf gimli = new Dwarf();

            DarkLord sauron = new DarkLord();

            gimli.ReceiveDamage(sauron.Attack());

            gimli.AddVictoryPoints(sauron.VictoryPoints);
            
            Assert.AreEqual(gimli.HealthMax, gimli.HealthActual);
        }
    }
}