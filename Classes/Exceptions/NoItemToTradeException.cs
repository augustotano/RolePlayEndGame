using System;

namespace Classes
{
    public  class NoItemToTradeException : System.Exception
    {
        public NoItemToTradeException() { }
        public NoItemToTradeException(string message) : base(message) { }
        public NoItemToTradeException(string message, System.Exception inner) : base(message, inner) { }
        protected NoItemToTradeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}