using System;

namespace Classes
{
    public class DefaultHandler : Handler
    {
        public override CharacterClass HandleRequest(string data)
        {
            throw new InvalidCharacterException("This character does not exist or it is badly written");
        }
    }
}