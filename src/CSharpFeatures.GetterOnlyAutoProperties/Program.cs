using System;

namespace CSharpFeatures.GetterOnlyAutoProperties
{
    public class Program
    {
        static void Main(string[] args)
        {
            var unit = new Unit();
            Console.WriteLine(unit.UnitId);
            Console.WriteLine(unit.UnitId);
        }
    }

    public class GetterWithDefault
    {
        public Guid Id { get; } = Guid.NewGuid();

        // public Guid get_Id()
        // {
        //     return Guid.NewGuid();
        // }
        
        // private readonly Guid _id = Guid.Empty;
        //
        // public Guid get_Id()
        // {
        //     return _id;
        // }
    }
    
    public class LambdaGetter
    {
        // Looks a property but...
        public Guid Id => Guid.NewGuid();
    }
    
    public class Unit
    {
        public Guid UnitId { get; } = Guid.NewGuid();
        // public Guid UnitId => Guid.NewGuid();
    }
}