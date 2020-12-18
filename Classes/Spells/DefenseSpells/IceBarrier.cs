using System;

namespace Classes
{
    public abstract class IceBarrier : DefenseSpell
    {   
        public IceBarrier (string name = "Ice Barrier", string description = "The wizard creates an Ice Barrier to shield themselves.") : base (name, description)
        {
            this.DefensePower = 50;
        }

        public override int UseSpell()
        {
            Console.WriteLine(this.Description);
            return this.DefensePower;
        }
    }
}