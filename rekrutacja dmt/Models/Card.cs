using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace rekrutacja_dmt
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
        public string PAN { get; set; }
        public bool PANvalid { get; set; }
        public bool Expired { get; set; }
        public string Name { get; set; }
        public VerificationMethod VerificationMethod { get; set; }

        public void IsPANvalid()
        {
            Logger.Out("Varyfying PAN correctness...");
            Regex r = new Regex("^;([0-9]+)=");
            Match m = r.Match(track2);
            int sum = 0, d;
            int a = 0;
            PAN = m.Groups[1].Value;
            for (int i = PAN.Length - 2; i >= 0; i--)
            {
                d = Convert.ToInt32(PAN.Substring(i, 1));
                if (a % 2 == 0)
                    d = d * 2;
                if (d > 9)
                    d -= 9;
                sum += d;
                a++;
            }

            PANvalid = ((10 - (sum % 10) == Convert.ToInt32(PAN.Substring(PAN.Length - 1))));
            if (PANvalid)
            {
                Logger.Out("    OK.");
            }
            else
            {
                Logger.Out("    PAN is not valid.");
            }
        }
        public void CheckExpirationDate()
        {
            Logger.Out("Checking expiration date...");
            Regex r = new Regex("=([0-9]{2})([0-9]{2})");
            Match m = r.Match(track2);
            int YY = Int32.Parse(m.Groups[1].Value);
            int MM = Int32.Parse(m.Groups[2].Value);
            int year = DateTime.Now.Year % 100;
            int month = DateTime.Now.Month;
            Expired = !(YY >= year & MM >= month);
            if (Expired)
            {
                Logger.Out("    Card has expired.");
            }
            else
            {
                Logger.Out("    OK.");
            }
        }

        public void CheckVerificationMethod()
        {
            //discuss: not sure if i am assessing verfifcation method correctly
            Logger.Out("Checking verification method...");
            Regex r = new Regex("=.{5}([0-9])");
            Match m = r.Match(track2);
            int n = Int32.Parse(m.Groups[1].Value);
            VerificationMethod = (VerificationMethod)n;
            Logger.Out($"    {VerificationMethod}");
        }
        public void AssessCardName(RangesList rangesList)
        {
            Logger.Out("Assesing card name...");
            foreach (Range range in rangesList.Ranges)
            {
                if (string.Compare(PAN.Substring(0,range.from.Length), range.from) >= 0
                    & string.Compare(PAN.Substring(0, range.to.Length), range.to) <= 0)
                {
                    Name = range.name;
                    break;
                }
            }
            if(Name == null)Logger.Out("    Cannot assess card name.");
            else Logger.Out($"    {Name}");
        }
    }
}
