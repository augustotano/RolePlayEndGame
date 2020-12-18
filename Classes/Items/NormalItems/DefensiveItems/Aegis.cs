using System;

namespace Classes
{
    public class Aegis : DefensiveItem, IFusionMaterial
    {
        Avalon FusionResult {get; set;}
        Excalibur OtherMaterial {get; set;}

        public Aegis(string name = "Aegis, the one shield")
        {
            this.Name = name;
            this.Magical = true;

            this.DefensePower = 40;
        }

        public Items Check()
        {
            Items Auxiliar = this;
            
            return Auxiliar;
        }

        public Items Fuse(IFusionMaterial material)
        {
            this.FusionResult = new Avalon();
            this.OtherMaterial = new Excalibur();
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