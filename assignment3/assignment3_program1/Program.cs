using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3_program1
{
    public interface IShape
    {
        bool Legal();
        double Area();
    }
    public class Triangle : IShape
    {
        public double a, b, c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool Legal()
        {
            if (a <= 0 || b <= 0 || c <= 0) return false;
            return (a < (b + c)) && (b < (c + a)) && (c < (a + b));
        }

        public double Area()
        {
            if (!Legal())
            {
                throw new InvalidOperationException("Not a valid triangle");
            }
            double semiPerimeter = (a + b + c) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
        }
    }
    public class Rectangle : IShape
    {
        public double a, b;

        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public bool Legal()
        {
            return a > 0 && b > 0;
        }

        public double Area()
        {
            if (!Legal())
            {
                throw new InvalidOperationException("Not a valid rectangle");
            }
            return a * b;
        }
    }
    public class Square : IShape
    {
        public double a;

        public Square(double a)
        {
            this.a = a;
        }

        public bool Legal()
        {
            return a > 0;
        }

        public double Area()
        {
            if (!Legal())
            {
                throw new InvalidOperationException("Not a valid square");
            }
            return a * a;
        }
    }
    public static class ShapeFactory
    {
        public static IShape CreateShape(string shapeType, params double[] dimensions)
        {
            if (dimensions == null || dimensions.Length == 0)
            {
                throw new ArgumentException("Dimensions cannot be empty");
            }

            switch (shapeType.ToLower())
            {
                case "triangle":
                    if (dimensions.Length != 3)
                        throw new ArgumentException("Triangle requires three dimensions.");
                    return new Triangle(dimensions[0], dimensions[1], dimensions[2]);

                case "rectangle":
                    if (dimensions.Length != 2)
                        throw new ArgumentException("Rectangle requires two dimensions.");
                    return new Rectangle(dimensions[0], dimensions[1]);

                case "square":
                    if (dimensions.Length != 1)
                        throw new ArgumentException("Square requires one dimension.");
                    return new Square(dimensions[0]);

                default:
                    throw new ArgumentException("Unknown shape type.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<IShape> shapes = new List<IShape>();
            double totalArea = 0;

            for (int i = 0; i < 10; i++)
            {
               
                string shapeType = GetRandomShapeType(random);
                IShape shape = null;

                
                switch (shapeType.ToLower())
                {
                    case "triangle":
                         
                        double a = random.Next(1, 10);
                        double b = random.Next(1, 10);
                        double c = random.Next(1, 10);
                        shape = ShapeFactory.CreateShape("triangle", a, b, c);
                        break;

                    case "rectangle":
                        
                        double width = random.Next(1, 10);
                        double height = random.Next(1, 10);
                        shape = ShapeFactory.CreateShape("rectangle", width, height);
                        break;

                    case "square":
                         
                        double side = random.Next(1, 10);
                        shape = ShapeFactory.CreateShape("square", side);
                        break;
                }

                if (shape != null && shape.Legal())
                {
                    double area = shape.Area();
                    totalArea += area;
                    Console.WriteLine($"{shapeType} 面积: {area}");
                }
                else
                {
                    Console.WriteLine($"{shapeType} 不合法.");
                }
            }

            Console.WriteLine($"总面积: {totalArea}");
            Console.ReadLine();
        }

        static string GetRandomShapeType(Random random)
        {
            string[] shapeTypes = { "Triangle", "Rectangle", "Square" };
            return shapeTypes[random.Next(shapeTypes.Length)];
        }
    }
}
