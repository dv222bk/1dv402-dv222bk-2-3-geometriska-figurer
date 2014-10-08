using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Program
    {
        private static Shape CreateShape(ShapeType shapeType)
        {
            string type = Extensions.AsText(shapeType);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine(Extensions.InsertEquals(Extensions.CenterAlignString(type, Properties.Strings.BoxLine)));
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
            Console.Title = Properties.Strings.Console_Title;
            while(true)
            {
                ViewMenu();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Properties.Strings.ChooseMenu);
                Console.ResetColor();
                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    if (answer >= 0 && answer <= 8)
                    {
                        Console.Clear();
                        Shape shape;
                        switch (answer)
                        {
                            case 0:
                                return; //Exit the program
                            case 1:
                                shape = CreateShape(ShapeType.Rectangle);
                                ViewShapeDetail(shape);
                                break;
                            case 2:
                                shape = CreateShape(ShapeType.Circle);
                                ViewShapeDetail(shape);
                                break;
                            case 3:
                                shape = CreateShape(ShapeType.Ellipse);
                                ViewShapeDetail(shape);
                                break;
                            case 4:
                                shape = CreateShape(ShapeType.Cuboid);
                                ViewShapeDetail(shape);
                                break;
                            case 5:
                                shape = CreateShape(ShapeType.Cylinder);
                                ViewShapeDetail(shape);
                                break;
                            case 6:
                                shape = CreateShape(ShapeType.Sphere);
                                ViewShapeDetail(shape);
                                break;
                            case 7:
                                ViewShapes(Randomize2DShapes());
                                break;
                            case 8:
                                ViewShapes(Randomize3DShapes());
                                break;
                        }
                    } 
                    else 
                    {
                        throw new OverflowException();
                    }
                }
                catch (FormatException)
                {
                    ViewMessage(Properties.Strings.MenuFormatError);
                }
                catch (OverflowException)
                {
                    ViewMessage(Properties.Strings.MenuNumberError);
                }
                ViewMessage(Extensions.CenterAlignString(Properties.Strings.Continue_Prompt, Properties.Strings.BoxLine), ConsoleColor.DarkBlue);
                Console.ReadKey();
                Console.Clear();
            }
        }
        private static Shape2D[] Randomize2DShapes()
        {
            Random random = new Random();
            int numShapes = random.Next(5, 21);
            Shape2D[] shapes = new Shape2D[numShapes];
            for (int i = 0; i < numShapes; i++)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        shapes[i] = new Ellipse(Extensions.NextDouble(random, 5.0, 100.0), Extensions.NextDouble(random, 5.0, 100.0));
                        break;
                    case 1:
                        shapes[i] = new Ellipse(Extensions.NextDouble(random, 5.0, 100.0));
                        break;
                    case 2:
                        shapes[i] = new Rectangle(Extensions.NextDouble(random, 5.0, 100.0), Extensions.NextDouble(random, 5.0, 100.0));
                        break;
                }
            }
            return shapes;
        }
        private static Shape3D[] Randomize3DShapes()
        {
            Random random = new Random();
            int numShapes = random.Next(5, 21);
            Shape3D[] shapes = new Shape3D[numShapes];
            for (int i = 0; i < numShapes; i++)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        shapes[i] = new Cuboid(Extensions.NextDouble(random, 5.0, 100.0), Extensions.NextDouble(random, 5.0, 100.0), Extensions.NextDouble(random, 5.0, 100.0));
                        break;
                    case 1:
                        shapes[i] = new Cylinder(Extensions.NextDouble(random, 5.0, 100.0), Extensions.NextDouble(random, 5.0, 100.0), Extensions.NextDouble(random, 5.0, 100.0));
                        break;
                    case 2:
                        shapes[i] = new Sphere(Extensions.NextDouble(random, 5.0, 100.0));
                        break;
                }
            }
            return shapes;
        }
        private static double[] ReadDimensions(ShapeType shapeType)
        {
            switch (shapeType.ToString())
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
                Console.WriteLine();
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
                    ViewMessage(Properties.Strings.DimensionsError);
                }
            }
        }
        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine(Properties.Strings.BoxEmptyLine);
            Console.WriteLine(Extensions.InsertEquals(Extensions.CenterAlignString(Properties.Strings.MainMenuHeader, Properties.Strings.BoxLine)));
            Console.WriteLine(Properties.Strings.BoxEmptyLine);
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine(Properties.Strings.Menu0);
            Console.WriteLine(Properties.Strings.Menu1);
            Console.WriteLine(Properties.Strings.Menu2);
            Console.WriteLine(Properties.Strings.Menu3);
            Console.WriteLine(Properties.Strings.Menu4);
            Console.WriteLine(Properties.Strings.Menu5);
            Console.WriteLine(Properties.Strings.Menu6);
            Console.WriteLine(Properties.Strings.Menu7);
            Console.WriteLine(Properties.Strings.Menu8);
            Console.WriteLine();
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine();
            Console.ResetColor();
        }
        private static void ViewShapeDetail(Shape shape)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.WriteLine(Extensions.InsertEquals(Extensions.CenterAlignString(Properties.Strings.ViewDetailsHeader, Properties.Strings.BoxLine)));
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(shape.ToString());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Properties.Strings.BoxLine);
            Console.ResetColor();
        }
        private static void ViewShapes(Shape[] shapes)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            if (shapes[0].IsShape3D)
            {
                Console.WriteLine(Properties.Strings.BoxLine3D);
                Console.WriteLine(Properties.Strings.Header3D);
                Console.WriteLine(Properties.Strings.BoxLine3D);
            }
            else
            {
                Console.WriteLine(Properties.Strings.BoxLine2D);
                Console.WriteLine(Properties.Strings.Header2D);
                Console.WriteLine(Properties.Strings.BoxLine2D);
            }
            Console.ResetColor();
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.ToString("R"));
            }
        }
        private static void ViewMessage(string message, ConsoleColor backgroundColor = ConsoleColor.Red, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine();
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}