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

namespace rekrutacja_dmt.Models
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
            Cards = JsonConvert.DeserializeObject<CardsList>(JsonString).Cards;
        }
    }
}
