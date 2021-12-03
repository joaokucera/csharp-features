namespace CSharpFeatures.InitOnlySetters
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Coords coords = new Coords(10, 10);
            // coords.X = 10;

            // Known object type shorthand instantiation
            // Coords coords = new();

            Coords coords = new Coords
            {
                X = 1,
                Y = 2
            };
            //
            // coords.X = 1;
            // coords.Y = 2;

            // Console.WriteLine(coords);
        }
    }

    /// <summary>
    /// Beginning with C# 7.2, you use the readonly modifier to declare that a structure type is immutable.
    /// The following code defines a readonly struct with init-only property setters, available from C# 9.0:
    /// </summary>
    public struct Coords
    //public readonly struct Coords
    {
        public Coords(double x, double y)
        {
            X = x;
            Y = y;
        }

        // public double X { get; }
        // public double Y { get; }

        // private double _z;
        // public /*readonly*/ double Z
        // {
        //     // readonly 
        //     get
        //     {
        //         _z += 1; 
        //         return _z; 
        //     }
        //     set
        //     {
        //         _z = value; 
        //     }
        // }
        
        // public double X { get; set; }
        // public double Y { get; set; }
        
        public double X { get; init; }
        public double Y { get; init; }

        // public string ToString() => $"({X}, {Y})";
        // public override string ToString()
        // {
        //     X = 0;
        //     return $"({X}, {Y})";
        // }
    }
}