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

        public abstract double Area
        {
            get;
        }
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
        public abstract double Perimeter
        {
            get;
        }
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
        protected Shape2D(ShapeType shapeType, double length, double width) 
            : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        public override string ToString()
        {
            string returnString;
            returnString = String.Format(Properties.Strings.Length2D, Length) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Width2D, Width) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Perimeter2D, Perimeter) + Environment.NewLine;
            returnString += String.Format(Properties.Strings.Area2D, Area);
            return returnString;
        }
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
