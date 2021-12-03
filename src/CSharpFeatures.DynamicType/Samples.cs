using System.Linq;

namespace CSharpFeatures.DynamicType
{
    public class Samples
    {
        private readonly dynamic _valueDynamic = new User
        {
            Name = "Joao"
        };
        
        private readonly User _valueActual = new()
        {
            Name = "Joao"
        };

        public string GetNameDynamic()
        {
            return _valueDynamic.Name;
        }
        
        public string GetNameActual()
        {
            return _valueActual.Name;
        }
        
        public dynamic GetNamesInListDynamic()
        {
            return Enumerable.Range(0, 10000).Select(x => _valueDynamic.Name).Cast<string>().ToList();
        }
        
        public dynamic GetNamesInListActual()
        {
            return Enumerable.Range(0, 10000).Select(x => _valueActual.Name).ToList();
        }
    }

    public record User
    {
        public string Name { get; init; }
    }
}