using System;

namespace Classes
{
    /*
    Herencia: Spell es abstracta y es heredada por los distintos subtipos de Spell.

    Polimorfismo: El metodo UseSpell() funciona distinto dependiendo de la subclase que la 
    implemente.

    OCP: Se pueden crear nuevos subtipos de Spell herendando esta clase, sin necesidad de modificar
    nada de lo existente, puesto que todas las spells tienen un nombre y una descripción.

    SRP: La única razón de cambio de cualquier Spell es un cambio en el uso de la Spell como tal.

    LSP: Si bien no se utiliza en esta clase, si no en Wizard, cuando se pide un objeto del tipo Spell,
    se podría reemplazar por cualquiera de sus subtipos y el funcionamiento sería el mismo. Esto 
    se debe a que todos los subtipos de Spell tienen los atributos de Spell.

    Expert: Los Spells son experts en su información, por lo que es natural que devuelvan su poder.
    */
    public abstract class Spell
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public Spell (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public abstract int UseSpell();
    }
}