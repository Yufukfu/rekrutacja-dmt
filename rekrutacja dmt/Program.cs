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
    internal class Programs
    {
        static void Main()
        {
            var rekrutacja = new Rekrutacja();
            string LogString = rekrutacja.Main();
        }
    }
}
