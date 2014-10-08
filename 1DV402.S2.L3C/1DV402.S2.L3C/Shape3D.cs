using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape3D : Shape
    {
        protected Shape2D _baseShape;
        private double _height;
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
                    throw new ArgumentException();
                }
                _height = value;
            }
        }
        public abstract double MantelArea
        {
            get;
        }
        public abstract double TotalSurfaceArea
        {
            get;
        }
        public abstract double Volume
        {
            get;
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
            if (this.Volume < obj.Volume)
            {
                return -1;
            }
            if (this.Volume > obj.Volume)
            {
                return 1;
            }
            return 0; // Else they are the same
        }
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height) : base(shapeType)
        {
            _baseShape = baseShape;
            Height = height;
        }
        public override string ToString()
        {
            string returnString;
            returnString = String.Format(Properties.Strings.Length3D, _baseShape.Length);
            returnString += String.Format(Properties.Strings.Width3D, _baseShape.Width);
            returnString += String.Format(Properties.Strings.Height3D, Height);
            returnString += String.Format(Properties.Strings.MantelArea3D, MantelArea);
            returnString += String.Format(Properties.Strings.TotalSurfaceArea3D, TotalSurfaceArea);
            returnString += String.Format(Properties.Strings.Volume3D, Volume);
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
                    return String.Format(Properties.Strings.Shape3DLine, ShapeType, _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurfaceArea, Volume);
                }
            }
            throw new FormatException();
        }
    }
}
