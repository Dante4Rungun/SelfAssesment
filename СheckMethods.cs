using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SelfAssessment
{
    public class СheckMethods
    {
        public static string sample()
        {
            string path = @"settings\default.txt";
            string chaos;
            using (StreamReader sr = new StreamReader(path))
            {
                chaos = sr.ReadToEnd();
            }
            return chaos;
        }

        public static string P12234ar()
        {
            string chaos = sample();
            string p12234ar = "";
            List<int> index = new List<int> { 0, 15, 30, 48, 59, 77, 92, 106, 117, 139, 154, 168, 177, 188, 197, 208, 217, 224 };
            for (int i = 0; i < index.Count; i++)
            {
                p12234ar = p12234ar + chaos[index[i]].ToString();
            }
            return p12234ar;
        }
    }
}
