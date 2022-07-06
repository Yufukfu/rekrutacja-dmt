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
        public string Main(string cards_filename = "CardsList.json", string ranges_filename = "Ranges.json", string log_filename = "log.txt")
        {
            string cards_schemaname = "CardsListSchema.json";
            string ranges_schemaname = "RangesSchema.json";

            var rangesList = new RangesList();
            rangesList.ReadFiles(ranges_filename, ranges_schemaname);
            if (rangesList.IsValid())
            {
                rangesList.Deserialize();
                rangesList.CheckOverlap();
            }
            var cardsList = new CardsList();
            cardsList.ReadFiles(cards_filename, cards_schemaname);
            if (cardsList.IsValid())
            {
                cardsList.Deserialize();
                cardsList.CheckCards(rangesList);
            }
            Logger.Log(log_filename);
            return Logger.LogString.ToString();
        }
    }
}
