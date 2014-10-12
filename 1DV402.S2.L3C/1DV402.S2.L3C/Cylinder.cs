using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Cylinder : Shape3D
    {
        /// <summary>
        /// Overrides the Shape3D MantelArea
        /// Counts the mantel area of the cylinder
        /// </summary>
        public override double MantelArea
        {
            get
            {
                return _baseShape.Perimeter * Height;
            }
        }
        /// <summary>
        /// Overrides the Shape3D TotalSurfaceArea
        /// Counts the total surface area of the cylinder
        /// </summary>
        public override double TotalSurfaceArea
        {
            get
            {
                return MantelArea + 2 * _baseShape.Area;
            }
        }
        /// <summary>
        /// Overrides the Shape3D Volume
        /// Counts the volume of the cylinder
        /// </summary>
        public override double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }
        /// <summary>
        /// Constructor. Creates a new cylinder shape.
        /// </summary>
        /// <param name="hradius">The horizontal radius of the cylinder</param>
        /// <param name="vradius">The vertical radius of the cylinder</param>
        /// <param name="height">The height of the cylinder</param>
        public Cylinder(double hradius, double vradius, double height) 
            : base(ShapeType.Cylinder, new Ellipse(hradius, vradius), height ) { }
    }
}
