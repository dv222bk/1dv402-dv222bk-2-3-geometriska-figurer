using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Sphere : Shape3D
    {
        /// <summary>
        /// Overrides the Shape3D MantelArea
        /// Counts the mantel area of the sphere
        /// </summary>
        public override double MantelArea
        {
            get
            {
                return _baseShape.Area * 4;
            }
        }
        /// <summary>
        /// Overrides the Shape3D TotalSurfaceArea
        /// Counts the total surface area of the sphere
        /// </summary>
        public override double TotalSurfaceArea
        {
            get
            {
                return _baseShape.Area * 4;
            }
        }
        /// <summary>
        /// Overrides the Shape3D Volume
        /// Counts the volume of the sphere
        /// </summary>
        public override double Volume
        {
            get
            {
                return 4 / 3 * _baseShape.Area * Height / 2;
            }
        }
        /// <summary>
        /// Constructor. Creates a new sphere shape
        /// </summary>
        /// <param name="radius">The radius of the sphere</param>
        public Sphere(double radius) 
            : base(ShapeType.Sphere, new Ellipse(radius * 2), radius * 2) { }
    }
}
