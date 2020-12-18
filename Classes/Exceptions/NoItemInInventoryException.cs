using System;

namespace Classes
{
    public  class NoItemInInventoryException : System.Exception
    {
        public NoItemInInventoryException() { }
        public NoItemInInventoryException(string message) : base(message) { }
        public NoItemInInventoryException(string message, System.Exception inner) : base(message, inner) { }
        protected NoItemInInventoryException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}