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
    public abstract class Json : IJson
    {

        protected string SchemaString { get; set; }
        protected string JsonString { get; set; }
       
        public void ReadFiles(string filepath, string schemapath)
        {
            try
            {
            JsonString = File.ReadAllText(filepath);
            SchemaString = File.ReadAllText(schemapath);
            Console.WriteLine(JsonString);

            }
            catch (FileNotFoundException e)
            {
                // FileNotFoundExceptions are handled here.
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        public bool IsValid()
        {
            JsonSchema schema = JsonSchema.Parse(SchemaString);
            JObject cards = JObject.Parse(JsonString);
            return cards.IsValid(schema);
        }
        public abstract void Deserialize();
     
    }
}
