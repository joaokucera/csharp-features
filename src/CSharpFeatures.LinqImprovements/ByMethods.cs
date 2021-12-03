using System;
using System.Linq;

namespace CSharpFeatures.LinqImprovements
{
    public class ByMethods
    {
        public ByMethods()
        {
            var countries = new[]
            {
                new Country("Brazil", 212600000),
                new Country("Germany", 83240000),
                new Country("Spain", 47350000)
            };

            //var lessPopulated_OLD = countries.OrderBy(x => x.Population).First();
            //var mostPopulated_OLD = countries.OrderByDescending(x => x.Population).First();
            
            // + DistinctBy, IntersectBy, UnionBy, AcceptBy
            var lessPopulated_NEW = countries.MinBy(x => x.Population);
            var mostPopulated_NEW = countries.MaxBy(x => x.Population);
            
            Console.ReadKey();
        }
    }
    
    public class Country
    {
        public string Name { get; }
        public int Population { get; }
        
        public Country(string name, int population)
        {
            Name = name;
            Population = population;
        }
    }
}