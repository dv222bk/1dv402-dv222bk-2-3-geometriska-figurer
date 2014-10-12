using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape2D : Shape, IComparable
    {
        private double _length;
        private double _width;

        /// <summary>
        /// Counts the area of the shape
        /// Abstract, is meant to be overrided by other classes.
        /// </summary>
        public abstract double Area
        {
            get;
        }
        /// <summary>
        /// Holds the length of the shape
        /// Get: Get the length of the shape
        /// Set: Set the length of the shape
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new OverflowException();
                }
                _length = value;
            }
        }
        /// <summary>
        /// Counts the perimeter of the shape
        /// Abstract, is meant to be overrided by other classes.
        /// </summary>
        public abstract double Perimeter
        {
            get;
        }
        /// <summary>
        /// Holds the width of the shape
        /// Get: Get the width of the shape
        /// Set: Set the width of the shape
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new OverflowException();
                }
                _width = value;
            }
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
            Shape2D otherShape2D = obj as Shape2D;
            if (otherShape2D != null) {
                return this.Area.CompareTo(otherShape2D.Area);
            }
            else
            {
                throw new FormatException();
            }
        }
        /// <summary>
        /// Constructor. Creates a new 2D shape.
        /// </summary>
        /// <param name="shapeType">Type of shape to create</param>
        /// <param name="length">Length of the shape</param>
        /// <param name="width">Width of the shape</param>
        protected Shape2D(ShapeType shapeType, double length, double width) 
            : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        /// <summary>
        /// Overrides the default ToString method.
        /// </summary>
        /// <returns>Returns a formated string with all the values of this shape</returns>
        public override string ToString()
        {
            string returnString;
            returnString = String.Format(Properties.Strings.Length2D, Length) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Width2D, Width) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Perimeter2D, Perimeter) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Area2D, Area);
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
                    return String.Format(Properties.Strings.Shape2DLine, ShapeType, Length, Width, Perimeter, Area);
                }
            }
            throw new FormatException();
        }
    }
}
