using System;

namespace Classes
{
    public  class NotEnoughItemsToTrade : System.Exception
    {
        public NotEnoughItemsToTrade() { }
        public NotEnoughItemsToTrade(string message) : base(message) { }
        public NotEnoughItemsToTrade(string message, System.Exception inner) : base(message, inner) { }
        protected NotEnoughItemsToTrade(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}