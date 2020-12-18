using System;

namespace Classes
{
    public  class NoItemInInventoryException : System.Exception
    {
        //Precondicion: que el booleano removed sea false
        //Poscondición: se envia un mensaje por consola, informando de la excepcion.
        //Invariantes: La lista de items se mantiene igual, el mensaje es el mismo.
        public NoItemInInventoryException() { }
        public NoItemInInventoryException(string message) : base(message) { }
        public NoItemInInventoryException(string message, System.Exception inner) : base(message, inner) { }
        protected NoItemInInventoryException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}