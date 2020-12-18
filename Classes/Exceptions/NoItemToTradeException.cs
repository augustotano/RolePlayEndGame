using System;

namespace Classes
{
    public  class NoItemToTradeException : System.Exception
    {
        //PreCondicion: que itemListCopy todavia tenga objetos dentro, esto quiere decir que no se pudieron intercambiar todos los items
        //PosCondicion: se envia un mensaje por consola informando de la excepcion.
        //Invariante: No se agregan objetos que no existen al personaje, el mensaje es el mismo
        public NoItemToTradeException() { }
        public NoItemToTradeException(string message) : base(message) { }
        public NoItemToTradeException(string message, System.Exception inner) : base(message, inner) { }
        protected NoItemToTradeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}