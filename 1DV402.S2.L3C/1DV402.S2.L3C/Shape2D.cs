using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape2D : Shape
    {
        private double _length;
        private double _width;

        public abstract double Area
        {
            get
            {
                return _length * _width;
            }
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
                    throw new ArgumentException();
                }
                _length = value;
            }
        }
        public abstract double Perimeter
        {
            get
            {
                return _length * 2 + _width * 2;
            }
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
                    throw new ArgumentException();
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
            if (this.GetType() != obj.GetType())
            {
                throw new ArgumentException();
            }
            if (this.Area < obj.Area)
            {
                return -1;
            }
            if (this.Area > obj.Area)
            {
                return 1;
            }

            return 0; // Else they are the same
        }
        protected Shape2D(ShapeType shapeType, double length, double width) : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        public override string ToString()
        {
            string returnString;
            returnString = String.Format(Properties.Strings.Length, Length) + "\n";
            returnString += String.Format(Properties.Strings.Width, Width) + "\n";
            returnString += String.Format(Properties.Strings.Perimeter, Perimeter) + "\n";
            returnString += String.Format(Properties.Strings.Area, Area) + "\n";
            return returnString;
        }
        public string ToString(string format)
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
