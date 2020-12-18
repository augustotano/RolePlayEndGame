using System;

namespace Classes
{
    public class AsclepiosWand : Items
    {
        public AsclepiosWand()
        {
            this.Name = "Asclepio's Wand";
            this.Magical = false;
        }

        public Items CombineMagicalProperty(Items item)
        {
            Excalibur NoMagicalItem = new Excalibur();
            NoMagicalItem.Magical = false;
            NoMagicalItem.Name += " Taimed";

            Console.WriteLine($"Now you can use {item.Name} thanks to the powers of the wand. However, as you used it, the wand dissappeared.");

            return NoMagicalItem;
        }
    }
}