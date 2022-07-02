using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekrutacja_dmt.Models
{
    public class Card
    {
        public string track2 { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public Address address { get; set; }
        public Type type { get; set; }
        public string company { get; set; }
    }
}
