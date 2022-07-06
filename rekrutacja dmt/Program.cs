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
    internal class Program
    {

        static void Main()
        {
            string filename1 = "CardsList.json";
            string filename2 = "Ranges.json";
            string schemaname1 = "CardsListSchema.json";
            string schemaname2 = "RangesSchema.json";

            var cardsList = new CardsList();
            cardsList.ReadFiles(filename1, schemaname1);
            cardsList.IsValid();
            cardsList.Deserialize();

            var rangesList = new RangesList();
            rangesList.ReadFiles(filename2, schemaname2);
            rangesList.IsValid();
            rangesList.Deserialize();

            foreach(Range range in rangesList.Ranges)
            {
                range.IsValid();
            }
            rangesList.CheckOverlap();

            foreach(Card card in cardsList.Cards)
            {
                card.IsPANvalid();
                card.CheckExpirationDate();
                card.CheckVerificationMethod();
                card.AssessCardName(rangesList);
            }


            Console.ReadLine();

        }
    }
}
