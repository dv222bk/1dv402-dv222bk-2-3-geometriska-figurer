using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Ellipse : Shape2D
    {
        public override double Area
        {
            get
            {
                return Math.PI * (Length / 2) * (Width / 2);
            }
        }
        public override double Perimeter
        {
            get
            {
                return Math.PI * Math.Sqrt(2 * (Length / 2) * (Length / 2) + 2 * (Width / 2) * (Width / 2));
            }
        }
        public Ellipse(double diameter) 
            : base(ShapeType.Circle, diameter, diameter) { }
        public Ellipse(double hdiameter, double vdiameter) 
            : base(ShapeType.Ellipse, hdiameter, vdiameter) { }
    }
}
