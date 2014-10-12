using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Cuboid : Shape3D
    {
        /// <summary>
        /// Overrides the Shape3D MantelArea
        /// Counts the mantel area of the cuboid
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
        /// Counts the total surface area of the cuboid
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
        /// Counts the total volume of the cuboid
        /// </summary>
        public override double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }
        /// <summary>
        /// Constructor. Creates a new cuboid shape.
        /// </summary>
        /// <param name="length">Length of the cuboid</param>
        /// <param name="width">Width of the cuboid</param>
        /// <param name="height">Height of the cuboid</param>
        public Cuboid(double length, double width, double height) 
            : base(ShapeType.Cuboid, new Rectangle(length, width), height ) { }
    }
}
