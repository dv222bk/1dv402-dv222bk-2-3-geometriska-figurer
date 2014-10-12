using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public static class Extensions
    {
        /// <summary>
        /// Translates the sent shapeType to a specific string meant for user to view
        /// </summary>
        /// <param name="shapeType">The shapeType to be translated</param>
        /// <returns>A translated shapeType. If a translation is missing, return a ToString()</returns>
        public static string AsText(this ShapeType shapeType)
        {
            switch (shapeType.ToString())
            {
                case ("Rectangle"):
                    return Properties.Strings.Rectangle;
                case ("Circle"):
                    return Properties.Strings.Circle;
                case ("Ellipse"):
                    return Properties.Strings.Ellipse;
                case ("Cuboid"):
                    return Properties.Strings.Cuboid;
                case ("Cylinder"):
                    return Properties.Strings.Cylinder;
                case ("Sphere"):
                    return Properties.Strings.Sphere;
            }
            return shapeType.ToString();
        }
        /// <summary>
        /// Aligns a string so it is center aligned in proportion to another string
        /// </summary>
        /// <param name="s">The string to be centered</param>
        /// <param name="other">The string to base the centering around</param>
        /// <returns>Returns the centered string</returns>
        public static string CenterAlignString(this string s, string other) //http://stackoverflow.com/questions/8200661/how-to-align-string-in-fixed-length-string
        {
            return s.PadLeft(((other.Length - s.Length) / 2) + s.Length).PadRight(other.Length);
        }
        /// <summary>
        /// Insertes "=" on the start and end of a string, removeing whatever character that was originally there.
        /// </summary>
        /// <param name="s">The string to have "=" inserted into it.</param>
        /// <returns>Returns the formated string</returns>
        public static string InsertEquals(this string s)
        {
            s = s.Remove(0, 1);
            s = s.Remove(s.Length - 1, 1);
            return "=" + s + "=";
        }
        /// <summary>
        /// Returns a random double
        /// </summary>
        /// <param name="random">A random number generator</param>
        /// <param name="minValue">The minimum value the double can have</param>
        /// <param name="maxValue">The maximum value the double can have</param>
        /// <returns>Returns a random double</returns>
        public static double NextDouble(this Random random, double minValue, double maxValue) //http://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
