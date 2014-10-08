using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Program
    {
        private Shape CreateShape(ShapeType shapeType)
        {
            string type = Extensions.AsText(shapeType);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine(Extensions.CenterAlignString(type, Properties.Strings.BoxLine));
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.ResetColor();
            double[] Dimensions = ReadDimensions(shapeType);
            switch (type)
            {
                case "Cuboid":
                    return new Cuboid(Dimensions[0], Dimensions[1], Dimensions[2]);
                case "Cylinder":
                    return new Cylinder(Dimensions[0], Dimensions[1], Dimensions[2]);
                case "Ellipse":
                    return new Ellipse(Dimensions[0], Dimensions[1]);
                case "Rectangle":
                    return new Rectangle(Dimensions[0], Dimensions[1]);
                case "Sphere":
                    return new Sphere(Dimensions[0]);
                default:
                    return new Ellipse(Dimensions[0]);
            }
        }
        static void Main(string[] args)
        {
            
        }
        private static double[] ReadDimensions(ShapeType shapeType)
        {
            switch (Extensions.AsText(shapeType))
            {
                case "Cuboid":
                    return ReadDoublesGreaterThanZero(Properties.Strings.CuboidPrompt, 3);
                case "Cylinder":
                    return ReadDoublesGreaterThanZero(Properties.Strings.CylinderPrompt, 3);
                case "Ellipse":
                    return ReadDoublesGreaterThanZero(Properties.Strings.EllipsePrompt, 2);
                case "Rectangle":
                    return ReadDoublesGreaterThanZero(Properties.Strings.RectanglePrompt, 2);
                case "Sphere":
                    return ReadDoublesGreaterThanZero(Properties.Strings.SpherePrompt);
                default:
                    return ReadDoublesGreaterThanZero(Properties.Strings.CirclePrompt);
            }
        }
        private static double[] ReadDoublesGreaterThanZero(string prompt, int numberOfValues = 1)
        {
            while(true) 
            {
                Console.Write(prompt);
                string answer = Console.ReadLine();
                string[] values = answer.Split(' ');
                double[] returnValues = new double[numberOfValues];
                try
                {
                    if (numberOfValues != values.Length)
                    {
                        throw new Exception();
                    }
                    for(int i = 0; i < numberOfValues; i++)
                    {
                        returnValues[i] = double.Parse(values[i]);
                        if (returnValues[i] <= 0)
                        {
                            throw new Exception();
                        }
                    }
                    return returnValues;
                }
                catch
                {
                    ShowError(Properties.Strings.DimensionsError);
                }
            }
        }
        private static void ShowError(string message,
            ConsoleColor backgroundColor = ConsoleColor.Red,
            ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}