using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape3D : Shape, IComparable
    {
        protected Shape2D _baseShape;
        private double _height;

        /// <summary>
        /// Holds the height of the shape
        /// Get: Get the height of the shape
        /// Set: Set the height of the shape
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new OverflowException();
                }
                _height = value;
            }
        }
        /// <summary>
        /// Counts the mantelarea of the shape
        /// Abstract, is meant to be overrided by other classes.
        /// </summary>
        public abstract double MantelArea
        {
            get;
        }
        /// <summary>
        /// Counts the total surface area of the shape
        /// Abstract, is meant to be overrided by other classes.
        /// </summary>
        public abstract double TotalSurfaceArea
        {
            get;
        }
        /// <summary>
        /// Counts the volume of the shape
        /// Abstract, is meant to be overrided by other classes.
        /// </summary>
        public abstract double Volume
        {
            get;
        }
        /// <summary>
        /// Compares this shape with another object, to help sorting methods sort it.
        /// </summary>
        /// <param name="obj">Object to compare this shape with</param>
        /// <returns>
        /// 1 if this shapes area is bigger than the objects
        /// 0 if this shapes area is the same as the objects
        /// -1 if this shapes area is smaller than the objects
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Shape3D otherShape3D = obj as Shape3D;
            if (otherShape3D != null)
            {
                return this.Volume.CompareTo(otherShape3D.Volume);
            }
            else
            {
                throw new FormatException();
            }
        }
        /// <summary>
        /// Constructor. Creates a new 3D shape.
        /// </summary>
        /// <param name="shapeType">Type of shape to be created</param>
        /// <param name="baseShape">The 2D shape to base the 3D shape on</param>
        /// <param name="height">The height of the shape</param>
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height) 
            : base(shapeType)
        {
            _baseShape = baseShape;
            Height = height;
        }
        /// <summary>
        /// Overrides the default ToString method.
        /// </summary>
        /// <returns>Returns a formated string with all the values of this shape</returns>
        public override string ToString()
        {
            string returnString;
            returnString = String.Format(Properties.Strings.Length3D, _baseShape.Length) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Width3D, _baseShape.Width) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Height3D, Height) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.MantelArea3D, MantelArea) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.TotalSurfaceArea3D, TotalSurfaceArea) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Volume3D, Volume);
            return returnString;
        }
        /// <summary>
        /// Returns a string of the shapes values.
        /// Overrides the ToString method in Shape.
        /// </summary>
        /// <param name="format">Asks for a specific format on the string the method returns</param>
        /// <returns>A string of the values of this shape</returns>
        public override string ToString(string format)
        {
            Regex regex = new Regex("G|R");
            Match match = regex.Match(format);
            if (match.Success || String.IsNullOrEmpty(format))
            {
                if ("G" == match.Value || String.IsNullOrEmpty(format))
                {
                    return ToString();
                }
                else if ("R" == match.Value)
                {
                    return String.Format(Properties.Strings.Shape3DLine, ShapeType, _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
                }
            }
            throw new FormatException();
        }
    }
}
