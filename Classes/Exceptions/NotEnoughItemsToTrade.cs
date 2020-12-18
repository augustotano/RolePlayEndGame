using System;

namespace Classes
{
    public  class NotEnoughItemsToTrade : System.Exception
    {
        //Precondicion: Giver no tiene el item que quiere tradear, por lo que tradeSucess = false.
        //Poscondicion: Se envia un mensaje por consola informando de la excepcion.
        //Invariantes: No cambia la lista de items del receiver, el mensaje se mantiene igual.
        public NotEnoughItemsToTrade() { }
        public NotEnoughItemsToTrade(string message) : base(message) { }
        public NotEnoughItemsToTrade(string message, System.Exception inner) : base(message, inner) { }
        protected NotEnoughItemsToTrade(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}