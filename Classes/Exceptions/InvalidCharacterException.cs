using System;

namespace Classes
{
    public  class InvalidCharacterException : System.Exception
    {
        /*
        Precondición: Que el texto recibido por el defaulthandler se haya podido manejar por handlers anteriores
        PosCondición: Se envia un mensaje por consola indicando de la excepción.
        Invariante: El mensaje enviado es el mismo, no se crean personajes.
        */
        public InvalidCharacterException() { }
        public InvalidCharacterException(string message) : base(message) { }
        public InvalidCharacterException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidCharacterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}