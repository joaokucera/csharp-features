using System;

namespace CSharpFeatures.RecordClassStructs
{
    public class Program
    {
        static void Main(string[] args)
        {
            PersonClass pc1 = new PersonClass("Joao", 40);
            PersonClass pc2 = new PersonClass("Joao", 40);

            Console.WriteLine(pc1 == pc2); // false

            PersonRecord pr1 = new PersonRecord("Joao", 40);
            PersonRecord pr2 = new PersonRecord("Joao", 40);

            Console.WriteLine(pr1 == pr2); // true
            
            // pr2.Name = "Test"; // it will break immutability
            // PersonRecord pr3 = new PersonRecord { Name = "Joao", Age = 40 };
        }
    }

    public class PersonClass
    {
        public string Name { get; }
        public int Age { get; set; }
        
        public PersonClass(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"PersonClass: {Name}, {Age}";
        }
    }
    
    // It assumes it is a class (up to C# 9.0)
    public record PersonRecord(string Name, int Age);
    // {
    //     public string Name { get; set; }
    //     public int Age { get; }
    //     
    //     public PersonRecord(string name, int age)
    //     {
    //         Name = name;
    //         Age = age;
    //     }
    //     
    //     // public override string ToString()
    //     // {
    //     //     return $"PersonClass: {Name}, {Age}";
    //     // }
    // }

    // C# 10
    // public record struct PersonWithStruct(string Name);
    // public record class PersonWithClass(string Name); // due to backwards compatibility
}