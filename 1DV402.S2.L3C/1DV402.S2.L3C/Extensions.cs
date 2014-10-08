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
            string returnString = "";
            returnString.PadLeft(((other.Length - s.Length) / 2) + s.Length).PadRight(other.Length); //http://stackoverflow.com/questions/8200661/how-to-align-string-in-fixed-length-string
            return returnString;
        }
        public static string InsertEquals(this string s)
        {
            s.Remove(0, 1);
            s.Remove(s.Length - 1, 1);
            return "=" + s + "=";
        }
        public static double NextDouble(this Random random, double minValue, double maxValue) //http://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
