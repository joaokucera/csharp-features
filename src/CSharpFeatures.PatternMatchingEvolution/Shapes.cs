using System;

namespace CSharpFeatures.PatternMatchingEvolution
{
    public interface ISquare
    {
        double Height { get; set; }
        double Width { get; set; }
    }

    public abstract class Shape
    {
        public abstract double Area { get; }

        // C# 10
        public Shape ShapeInShape { get; set; }
    }

    public class Rectangle : Shape, ISquare
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area => Height * Width;
        
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
    }
    
    public class Circle : Shape
    {
        private const double PI = Math.PI;
        
        public double Diameter { get; }

        public Circle(double diameter)
        {
            Diameter = diameter;
        }
        
        public double Radius => Diameter / 2.0;
        public override double Area => PI * Radius * Radius;
    }
}