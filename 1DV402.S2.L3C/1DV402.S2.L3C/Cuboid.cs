using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public class Cuboid : Shape3D
    {
        public double MantelArea
        {
            get
            {
                return _baseShape.Perimeter * Height;
            }
        }
        public double TotalSurfaceArea
        {
            get
            {
                return MantelArea + 2 * _baseShape.Area;
            }
        }
        public double Volume
        {
            get
            {
                return _baseShape.Area * Height;
            }
        }
        public Cuboid(double length, double width, double height) 
            : base(ShapeType.Cubiod, new Rectangle(length, width), height ) { }
    }
}
