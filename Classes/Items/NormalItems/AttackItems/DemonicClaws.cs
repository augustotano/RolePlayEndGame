using System;

namespace Classes
{
    public class DemonicClaws : OffensiveItem, IFusionMaterial
    {
        WillBreaker FusionResult {get; set;}
        FrostMourne OtherMaterial {get; set;}

        public DemonicClaws(string name = "Demonic Claws")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 40;
        }

        public Items Check()
        {
            Items Auxiliar = this;
            
            return Auxiliar;
        }

        public Items Fuse(IFusionMaterial material)
        {
            this.OtherMaterial = new FrostMourne();
            this.FusionResult = new WillBreaker();
            
            if(material.Check().Name == this.OtherMaterial.Check().Name)
            {
                return FusionResult;
            }
            else
            {
                return this;
            }
        }
    }
}