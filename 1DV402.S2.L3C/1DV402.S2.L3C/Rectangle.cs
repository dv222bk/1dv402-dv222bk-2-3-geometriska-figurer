using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Rectangle : Shape2D
    {
        /// <summary>
        /// Overrides the Shape2D Area
        /// Counts the area of the rectangle
        /// </summary>
        public override double Area
        {
            get
            {
                return Length * Width;
            }
        }
        /// <summary>
        /// Overrides the Shape2D Perimeter
        /// Counts the perimeter of the rectangle
        /// </summary>
        public override double Perimeter
        {
            get
            {
                return 2 * Length + 2 * Width;
            }
        }
        /// <summary>
        /// Constructor. Creates a new rectangle shape
        /// </summary>
        /// <param name="length">The length of the rectangle</param>
        /// <param name="width">The width of the rectangle</param>
        public Rectangle(double length, double width) 
            : base(ShapeType.Rectangle, length, width) { }
    }
}
