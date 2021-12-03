using System;
using System.Collections.Generic;

namespace CSharpFeatures.PatternMatchingEvolution
{
    public class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle(5);
            var rectangle = new Rectangle(420, 1337);
            var square = new Rectangle(69, 69);

            var shapes = new List<Shape> {circle, rectangle, square};
            var randomShape = shapes[new Random().Next(shapes.Count)];

            // C# 6
            // CSharp6(randomShape);
            
            // C# 7
            // CSharp7(randomShape);
            
            // C# 8
            // CSharp8(randomShape);
            
            // C# 9
            // CSharp9(randomShape);
            
            // C# 10
            // CSharp10(randomShape);
        }

        static void CSharp6(Shape randomShape)
        {
            if (randomShape is Circle)
            {
                var cir = (Circle)randomShape;
                //var cir = randomShape as Circle;
                Console.WriteLine($"Circle with area {cir.Diameter}");
            }
        }

        static void CSharp7(Shape randomShape)
        {
            // no extra casting
            if (randomShape is Circle cir)
            {
                Console.WriteLine($"Circle with area {cir.Diameter}");
            }
            
            switch (randomShape)
            {
                case Circle c:
                    Console.WriteLine($"Circle with area {c.Diameter}");
                    break;
                case Rectangle r when r.Height == r.Width:
                    Console.WriteLine($"This is a square");
                    break;
                default:
                    Console.WriteLine($"Nothing to do here");
                    break;
            }
        }
        
        static void CSharp8(Shape randomShape)
        {
            if (randomShape is Circle {Radius: 10, Area: 50})
            {
            }
            
            var shapeDetails = randomShape switch
            {
                Circle _ => "This is a circle",
                Rectangle rec when rec.Height == rec.Width => "This is a square",
                {Area:100} => "This area was 100",
                //{Area:>100} => "This area was 100", // not possible
                _ => "This is a default, Didn't match anything"
            };
            
            Console.WriteLine(shapeDetails);
        }
        
        static void CSharp9(Shape randomShape)
        {
            // if (randomShape is null)
            // {
            // }
            //
            // if (randomShape is not null)
            // {
            // }
            
            if (randomShape is not Rectangle)
            {
            }
            
            if (randomShape is Circle {Radius: > 100 and < 200, Area: >= 1000})
            {
            }
            
            var shapeDetails = randomShape switch
            {
                Circle {Area: > 100 and < 200} => "This is a special circle",
                Circle {Diameter: 100} => "This is a circle with diameter 100",
                _ => "This is a default, Didn't match anything"
            };
            
            var areaDetails = randomShape.Area switch
            {
                >= 100 and <= 200 => "",
                _ => ""
            };
            
            Console.WriteLine(shapeDetails);
        }
        
        static void CSharp10(Shape randomShape)
        {
            if (randomShape is Rectangle { ShapeInShape: { Area: 100 } })
            {
            }
            
            if (randomShape is Rectangle { ShapeInShape.Area: 100 })
            {
            }
        }

        // with Tuple (... show lowering)
        private static double GetGroupTicketPriceDiscount(int groupSize, DateTime visitDate) =>
            (groupSize, visitDate.DayOfWeek) switch
            {
                (<= 0, _) => throw new ArgumentException("Group size must be positive"),
                (_, DayOfWeek.Saturday or DayOfWeek.Sunday) => 0.0,
                (>= 5 and < 10, DayOfWeek.Monday) => 20.0,
                (>= 10, DayOfWeek.Monday) => 30.0,
                (>= 5 and < 10, _) => 12.0,
                (>= 10, _) => 15.0,
                _ => 0.0
            };
    }
    
    public static class Extensions
    {
        public static bool IsLetter(this char c) =>
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
    }
}