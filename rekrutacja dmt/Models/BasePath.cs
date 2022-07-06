using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rekrutacja_dmt
{
    internal static class BasePath
    {
        public static string Get()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        }
    }
}
