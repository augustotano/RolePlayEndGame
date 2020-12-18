using System;
using System.Collections.Generic;

namespace Classes
{
    /*
    Mayor información en la interfaz.
    */
    public class ExchangeEncounter : IEncounter
    {
        public CharacterClass Giver {get; set;}
        public CharacterClass Receiver {get; set;}
        public string ItemName {get; set;}
        public List<string> ItemsList {get; set;}
        
        public ExchangeEncounter(CharacterClass giver, CharacterClass receiver, string itemName)
        {
            this.Giver = giver;
            this.Receiver = receiver;
            this.ItemName = itemName;
            this.ItemsList = new List<string> ();
        }

        public ExchangeEncounter(CharacterClass giver, CharacterClass receiver, List<string> stringList)
        {
            this.Giver = giver;
            this.Receiver = receiver;
            this.ItemsList = stringList;
        }

        public List<List<CharacterClass>> PlayEncounter()
        {
            List<CharacterClass> giverList = new List<CharacterClass>();
            List<CharacterClass> receiverList = new List<CharacterClass>();
            List<List<CharacterClass>> returnableList = new List<List<CharacterClass>>(){giverList,receiverList};

            bool tradeSuccess = false;

            if(this.ItemsList.Count == 0)
            {
                List<Items> giverItemsListCopy = new List<Items>();

                giverItemsListCopy.AddRange(this.Giver.ItemList);

                foreach(Items item in giverItemsListCopy)
                {
                    if(item.Name == this.ItemName)
                    {
                        this.Giver.RemoveItem(item);
                        this.Receiver.AddItem(item);
                        tradeSuccess = true;
                    }
                }
                
                if(!tradeSuccess)
                {
                    //Precondicion: Giver no tiene el item que quiere tradear, por lo que tradeSucess = false.
                    //Poscondicion: Se envia un mensaje por consola informando de la excepcion.
                    //Invariantes: No cambia la lista de items del receiver, el mensaje se mantiene igual.
                    throw new NoItemToTradeException($"{Giver.Name} doesn't have the requiered item.");
                }
            }

            else
            {
                List<string> itemsListCopy = new List<string>();
                List<Items> giverItemsListCopy = new List<Items>();

                giverItemsListCopy.AddRange(this.Giver.ItemList);
                itemsListCopy.AddRange(this.ItemsList);

                foreach(string name in this.ItemsList)
                {
                    foreach(Items item in giverItemsListCopy)
                    {
                        if(item.Name == name)
                        {
                            this.Giver.RemoveItem(item);
                            this.Receiver.AddItem(item);
                            itemsListCopy.Remove(name);
                        }
                    }
                }

                if(itemsListCopy.Count != 0)
                {
                    //PreCondicion: que itemListCopy todavia tenga objetos dentro, esto quiere decir que no se pudieron intercambiar todos los items
                    //PosCondicion: se envia un mensaje por consola informando de la excepcion.
                    //Invariante: No se agregan objetos que no existen al personaje, el mensaje es el mismo
                    throw new NotEnoughItemsToTrade($"Some items have been exchanged, but the giver did not have all the items it wanted to exchange.");

                }
            }

            returnableList[0].Add(this.Giver);
            returnableList[1].Add(this.Receiver);
            
            return returnableList;
        }
    }
    
}