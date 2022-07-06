using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace rekrutacja_dmt
{
    public static class Logger
    {
        public static StringBuilder LogString = new StringBuilder();
        public static void Out(string str)
        {
            Console.WriteLine(str);
            LogString.Append(str).Append(Environment.NewLine);
        }
        public static void Log(string filename)
        {
            string str = LogString.ToString();
            //string filename = DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
            string path = $@"{BasePath.Get()}\Logs\{filename}";
            try
            {
            File.WriteAllText(path, str);
            }
            catch (Exception e)
            {
                Logger.Out("    Cannot save this file.");
                Logger.Out($"   {e.Message}");
                Logger.Out("");
                Console.ReadLine();
                return;
            }
        }
    }
}
