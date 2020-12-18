using System;

namespace Classes
{
    public  class InvalidCharacterException : System.Exception
    {
        public InvalidCharacterException() { }
        public InvalidCharacterException(string message) : base(message) { }
        public InvalidCharacterException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidCharacterException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}