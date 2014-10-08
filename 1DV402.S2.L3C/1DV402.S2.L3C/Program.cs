using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private Shape CreateShape(ShapeType shapeType)
        {
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine(Extensions.CenterAlignString(Extensions.AsText(shapeType), Properties.Strings.BoxLine));
            Console.WriteLine(Properties.Strings.BoxLine);
        }
        private static double[] ReadDimensions(ShapeType shapeType)
        {

        }
        private static double[] ReadDoublesGreaterThanZero()
        {

        }
    }
}