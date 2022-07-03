using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace rekrutacja_dmt.Models
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
            Ranges = JsonConvert.DeserializeObject<RangesList>(JsonString).Ranges;
        }
        public void CheckOverlap()
        {
            Overlap = false;
            Ranges.Sort((x, y) => x.to.CompareTo(y.to));
            for(int i = 0; i < Ranges.Count - 1; i++)
            {
                int o = string.Compare(Ranges[i].to, Ranges[i + 1].from);
                if (o > 0)
                {
                    Overlap = true;
                    break;
                }
            }
        }
    }

}
