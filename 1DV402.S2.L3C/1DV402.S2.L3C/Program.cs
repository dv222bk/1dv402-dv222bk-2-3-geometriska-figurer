using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private Shape CreateShape(ShapeType shapeType)
        {
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine(Extensions.CenterAlignString(Extensions.AsText(shapeType), Properties.Strings.BoxLine));
            Console.WriteLine(Properties.Strings.BoxLine);
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
                case "Circle":
                    return ReadDoublesGreaterThanZero(Properties.Strings.CirclePrompt);
            }
            throw new ArgumentException(); //If ShapeType has an impossible value
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