using System;

namespace Classes
{
    public  class InvalidEncounterException : System.Exception
    {
        //Precondición: Que el tipo de encuentro ingresado no haya podido ser manejado por los if else if
        //Poscondición: Se envía un mensaje por consola indicando de la excepcion.
        //Invariante: No se crea ningún nuevo encuentro, el mensaje siempre es el mismo.
        public InvalidEncounterException() { }
        public InvalidEncounterException(string message) : base(message) { }
        public InvalidEncounterException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidEncounterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}