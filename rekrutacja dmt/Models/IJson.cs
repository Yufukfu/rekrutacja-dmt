using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekrutacja_dmt
{
    internal interface IJson
    {
        void ReadFiles(string filename, string schemaname);
        bool IsValid();
        void Deserialize();
    }
}
