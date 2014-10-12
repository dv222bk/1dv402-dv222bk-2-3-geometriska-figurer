﻿using System;
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
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height) 
            : base(shapeType)
        {
            _baseShape = baseShape;
            Height = height;
        }
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
