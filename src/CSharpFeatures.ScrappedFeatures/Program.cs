using System;

namespace CSharpFeatures.ScrappedFeatures
{
    public class Program
    {
        static void Main(string[] args)
        {
            // REQUIRED keyword
            var person = new Person();
            
            Console.WriteLine($"Name was NOT initialized");
            // Console.WriteLine($"Name NEEDS TO BE initialized");
            Console.WriteLine($"Neither was Age");
            
            // FIELD keyword
            // => DateOfBirth
            
            // GENERIC ATTRIBUTES
            // => PersonAttribute
        }
    }

    public class Person
    {
        // It will provide a way to make fields mandatory without creating constructors
        public /*required*/ string Name { get; set; }
        public int Age { get; init; }
        
        // _BackingField
        // public DateTime DateOfBirth { get; set => field = value.Date; }

        private DateTime _dateOfBirth;

        // Eliminating the need of having such declaration
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value.Date;
            }
        }
    }

    public class PersonAttribute/*<MyType>*/ : Attribute
    {
        public Type Type { get; set; }
        //public MyType Type { get; set; }
    }
}