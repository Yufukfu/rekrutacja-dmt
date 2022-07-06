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
using System.Text.RegularExpressions;

namespace rekrutacja_dmt

{
    internal class Rekrutacja
    {
        public string Main(string filename1 = "CardsList.json", string filename2 = "Ranges.json")
        {
            string schemaname1 = "CardsListSchema.json";
            string schemaname2 = "RangesSchema.json";

            var rangesList = new RangesList();
            rangesList.ReadFiles(filename2, schemaname2);
            if (rangesList.IsValid())
            {
                rangesList.Deserialize();
                rangesList.CheckOverlap();
            }
            var cardsList = new CardsList();
            cardsList.ReadFiles(filename1, schemaname1);
            if (cardsList.IsValid())
            {
                cardsList.Deserialize();
                cardsList.CheckCards(rangesList);
            }
            return Logger.LogString.ToString();
        }
    }
}
