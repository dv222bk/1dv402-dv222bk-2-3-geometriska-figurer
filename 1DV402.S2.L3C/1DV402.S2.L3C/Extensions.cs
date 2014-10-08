using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public static class Extensions
    {
        public static string AsText(this ShapeType shapeType)
        {
            return shapeType.ToString();
        }
        public static string CenterAlignString(this string s, string other)
        {
            string returnString = "=";
            returnString.PadLeft(((other.Length - s.Length - 1) / 2) + s.Length).PadRight(other.Length - 1); //http://stackoverflow.com/questions/8200661/how-to-align-string-in-fixed-length-string
            returnString += "=";
            return returnString;
        }
    }
}
