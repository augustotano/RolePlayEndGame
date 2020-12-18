using System;

namespace Classes
{
    public class DefaultHandler : Handler
    {
        /*
        Precondición: Que el texto recibido por el defaulthandler se haya podido manejar por handlers anteriores
        PosCondición: Se envia un mensaje por consola indicando de la excepción.
        Invariante: El mensaje enviado es el mismo, no se crean personajes.
        */
        public override CharacterClass HandleRequest(string data)
        {
            throw new InvalidCharacterException("This character does not exist or it is badly written");
        }
    }
}