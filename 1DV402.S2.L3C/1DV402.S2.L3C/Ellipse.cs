using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Ellipse : Shape2D
    {
        /// <summary>
        /// Overrides the Shape2D Area
        /// Counts the area of the ellipse
        /// </summary>
        public override double Area
        {
            get
            {
                return Math.PI * (Length / 2) * (Width / 2);
            }
        }
        /// <summary>
        /// Overrides the Shape2D Perimeter
        /// Counts the perimeter of the ellipse
        /// </summary>
        public override double Perimeter
        {
            get
            {
                return Math.PI * Math.Sqrt(2 * (Length / 2) * (Length / 2) + 2 * (Width / 2) * (Width / 2));
            }
        }
        /// <summary>
        /// Constructor. Used to create a perfect circle shape.
        /// </summary>
        /// <param name="diameter">The diameter of the circle</param>
        public Ellipse(double diameter) 
            : base(ShapeType.Circle, diameter, diameter) { }
        /// <summary>
        /// Constructor. Used to create a ellipse shape.
        /// </summary>
        /// <param name="hdiameter">The horizontal diameter of the ellipse</param>
        /// <param name="vdiameter">The vertical diameter of the ellipse</param>
        public Ellipse(double hdiameter, double vdiameter) 
            : base(ShapeType.Ellipse, hdiameter, vdiameter) { }
    }
}
