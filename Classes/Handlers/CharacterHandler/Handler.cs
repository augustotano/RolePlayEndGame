using System;

namespace Classes
{
    /*
    COR: Uso de chain of responsability para facilitar la lectura de personajes del archivo de texto.
    SRP: Su unica responsabilidad y motivo de cambio es la manera en al que se maneja la información.
    OCP: Esta abierto a la creación de nuevos handlers mediante herencia sin modificar los ya existentes.
    Polimorfismo: HandleRequest es un metodo polimorfico que varía de handler en handler.
    */
    public abstract class Handler
    {
        protected Handler succesor;

        public void SetSucessor(Handler succesor)
        {
            this.succesor = succesor;
        }

        public abstract CharacterClass HandleRequest(string request);
    }
}