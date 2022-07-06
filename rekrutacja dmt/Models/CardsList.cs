using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace rekrutacja_dmt
{
    public class CardsList : Json
    {
        public List<Card> Cards { get; set; }
        
       
        public CardsList()
        {
            Cards = new List<Card>();
        }
        public override void Deserialize()
        {
            Logger.Out($"Deserializing {filename}");
            Cards = JsonConvert.DeserializeObject<CardsList>(JsonString).Cards;
            Logger.Out($"   {filename} deserialized.");
        }
        public void CheckCards(RangesList rangesList)
        {
            int i = 0;
            foreach (Card card in Cards)
            {
                i++;
                Logger.Out("");
                Logger.Out($"Checking card number {i}:");
                card.IsPANvalid();
                card.CheckExpirationDate();
                card.CheckVerificationMethod();
                card.AssessCardName(rangesList);
            }
        }
    }
}
