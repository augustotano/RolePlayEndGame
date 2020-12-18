using System;

namespace Classes
{
    public class Excalibur : OffensiveItem, IFusionMaterial
    {
        Avalon FusionResult {get; set;}
        Aegis OtherMaterial {get; set;}

        public Excalibur(string name = "Excalibur")
        {
            this.Name = name;
            this.Magical = true;

            this.AttackPower = 80;
        }

        public Items Check()
        {
            Items Auxiliar = this;
            
            return Auxiliar;
        }

        public Items Fuse(IFusionMaterial material)
        {
            this.FusionResult = new Avalon();
            this.OtherMaterial = new Aegis();
            
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