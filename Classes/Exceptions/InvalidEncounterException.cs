using System;

namespace Classes
{
    public  class InvalidEncounterException : System.Exception
    {
        public InvalidEncounterException() { }
        public InvalidEncounterException(string message) : base(message) { }
        public InvalidEncounterException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidEncounterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}