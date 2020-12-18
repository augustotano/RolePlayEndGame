using System;

namespace Classes
{
    public class FrostMourne : OffensiveItem, IFusionMaterial
    {
        ShadowMourne FusionResult {get; set;}
        StygianBlade OtherMaterial {get; set;}

        public FrostMourne(string name = "Frostmourne")
        {
            this.Name = name;
            this.Magical = false;

            this.AttackPower = 79;
        }

        public Items Check()
        {
            Items Auxiliar = this;
            
            return Auxiliar;
        }

        public Items Fuse(IFusionMaterial material)
        {
            this.FusionResult = new ShadowMourne();
            this.OtherMaterial = new StygianBlade();
            
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