using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace rekrutacja_dmt
{
    public class RangesList : Json
    {
        public List<Range> Ranges { get; set; }
        public bool Overlap { get; set; }

        public RangesList()
        {
            Ranges = new List<Range>();
        }
        public override void Deserialize()
        {
            Logger.Out($"Deserializing {filename}...");
            Ranges = JsonConvert.DeserializeObject<RangesList>(JsonString).Ranges;
            Logger.Out($"   {filename} deserialized.");
        }
        public void CheckOverlap()
        {
            Logger.Out("Checking ranges for overlap...");
            foreach (Range range in Ranges)
            {
                range.IsValid();
            }
            Overlap = false;
            List<Range> SortedRanges = Ranges.OrderBy(o => o.from).ToList();
            for (int i = 0; i < Ranges.Count - 1; i++)
            {
                int c = string.Compare(SortedRanges[i].to, SortedRanges[i + 1].from);
                if (c > 0)
                {
                    Overlap = true;
                    Logger.Out($"    Ranges {SortedRanges[i].from}-{SortedRanges[i].to} and {SortedRanges[i + 1].from}-{SortedRanges[i + 1].to} are overlaping");
                    Logger.Out("    Card name assessment may vary depending on ranges order in .json file.");
                    break;
                }
            }
            if (!Overlap) Logger.Out("    Ranges are not overlaping.");
        }
    }

}
