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
    internal class Program
    {
        static void Main()
        {
            string filename = "File1.json";
            string schemapath = "File1-schema.json";
            var cardsList = new CardsList(filename, schemapath);
            cardsList.IsValid();
            cardsList.Deserialize();

           


            Console.WriteLine($"{cardsList.cards[1].lastName}");
            Console.ReadLine();

        }
    }
}
