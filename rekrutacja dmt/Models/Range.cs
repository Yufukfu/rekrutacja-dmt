using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekrutacja_dmt.Models
{
    public class Range
    {
        public string from { get; set; }
        public string to { get; set; }
        public string name { get; set; }
        public bool Valid { get; set; }
        public void IsValid()
        {
            Valid = string.Compare(to, from) == 1;
        }

    }
}
