using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchFair
{
    class algoritma
    {
        private string rev(string s)
        {
            char[] c = s.ToCharArray();
            string ts = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                ts += c[i].ToString();
            }

            return (ts);

        }
        public static string ramz;
        public static string Close_Nazarsajni = "false";
          
    }
}
