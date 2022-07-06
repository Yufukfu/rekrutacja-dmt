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
        protected string filename { get; set; }
        protected string schemaname { get; set; }
       
        public void ReadFiles(string file, string schema)
        {
            Logger.Out("");
            Logger.Out($"Reading file '{file}'...");
            try
            {
            JsonString = File.ReadAllText($"./Files/{file}");
            SchemaString = File.ReadAllText($"./Schemas/{schema}");
            //Console.WriteLine(JsonString);

            }
            catch (FileNotFoundException e)
            {
                // FileNotFoundExceptions are handled here.
                Logger.Out("    Cannot read this file.");
                Logger.Out($"   {e.Message}");
                Logger.Out("");
                Console.ReadLine();
                return;
            }
            Logger.Out("    File read succesfuly.");
            filename = file;
            schemaname = schema;
        }
        public bool IsValid()
        {
            if (filename != null & schemaname != null)
            {

                Logger.Out($"Validating {filename} using {schemaname}...");
                JsonSchema schema = JsonSchema.Parse(SchemaString);
                JObject cards = JObject.Parse(JsonString);
                if (cards.IsValid(schema))
                {
                    Logger.Out("    File is valid.");
                    return true;
                }
                else
                {
                    Logger.Out("    File is not valid.");
                    return false;
                };
            }else return false;
        }
        public abstract void Deserialize();

    }
}
