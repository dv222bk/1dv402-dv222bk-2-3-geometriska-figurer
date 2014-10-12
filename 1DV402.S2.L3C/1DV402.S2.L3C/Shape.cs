using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    /// <summary>
    /// ShapeType can have the following values:
    /// Rectangle
    /// Circle
    /// Ellipse
    /// Cuboid
    /// Cylinder
    /// Sphere
    /// </summary>
    public enum ShapeType { Rectangle, Circle, Ellipse, Cuboid, Cylinder, Sphere };

    public abstract class Shape
    {
        /// <summary>
        /// Checks if the shape is 3D or 2D.
        /// Returns true if shape is 3D, false if not.
        /// </summary>
        public bool IsShape3D
        {
            get
            {
                if (ShapeType == ShapeType.Cylinder || ShapeType == ShapeType.Sphere || ShapeType == ShapeType.Cuboid)
                {
                    return true;
                }
                return false;
            }             
        }
        /// <summary>
        /// ShapeType that holds information about this shapes type
        /// Get: get the current type
        /// Set: set the current type (private)
        /// </summary>
        public ShapeType ShapeType
        {
            get;
            private set;
        }
        /// <summary>
        /// Constructor. Creates a new shape.
        /// </summary>
        /// <param name="shapeType">The type of shape to be created.</param>
        protected Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }
        /// <summary>
        /// Returns a string of the shapes values.
        /// Abstract, is meant to be overrided by other classes.
        /// </summary>
        /// <param name="format">Asks for a specific format on the string the method returns</param>
        /// <returns>A string of the values of this shape</returns>
        public abstract string ToString(string format);
    }
}
