using System;

namespace Classes
{
    public class StygianBlade : OffensiveItem, IFusionMaterial
    {
        ShadowMourne FusionResult {get; set;}
        FrostMourne OtherMaterial {get; set;}

        public StygianBlade(string name = "Stygian Blade")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 45;
        }

        public Items Check()
        {
            Items Auxiliar = this;
            
            return Auxiliar;
        }

        public Items Fuse(IFusionMaterial material)
        {
            this.OtherMaterial = new FrostMourne();
            this.FusionResult = new ShadowMourne();
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