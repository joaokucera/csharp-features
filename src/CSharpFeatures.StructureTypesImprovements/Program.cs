using System;

namespace CSharpFeatures.StructureTypesImprovements
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(420, 69);
            
            // C# 10.0
            // var rectangle1 = new Rectangle();
            
            // var newRectangle = rectangle;
            // newRectangle.Width = 0;
            
            // C# 10.0
            // var newRectangle = rectangle with {Width = 0};
            
            // Console.WriteLine(rectangle);
            // Console.WriteLine(newRectangle);
        }
    }
    
    public struct Rectangle
    {
        // C# 10.0
        public Rectangle()
        {
            Height = 10;
            Width = 20;
        }
        
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        // public int Height { get; init; }
        // public int Width { get; init; }

        public override string ToString()
        // public readonly override string ToString()
        {
            return $"Rectangle: {Height} | {Width}";
        }
    }
}