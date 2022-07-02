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
    public class CardsList
    {
        public List<Card> cards { get; set; }
        private string SchemaString { get; set; }
        private string JsonString { get; set; }
       
        public CardsList(string filepath, string schemapath)
        {
            if(filepath != null & schemapath != null)
            {

            JsonString = File.ReadAllText(filepath);
            SchemaString = File.ReadAllText(schemapath);
            Console.WriteLine(JsonString);
            }
        }

        public bool IsValid()
        {
            JsonSchema schema = JsonSchema.Parse(SchemaString);
            JObject cards = JObject.Parse(JsonString);
            return cards.IsValid(schema);
        }
        public void Deserialize()
        {
            cards = JsonConvert.DeserializeObject<CardsList>(JsonString).cards;
        }
    }
}
