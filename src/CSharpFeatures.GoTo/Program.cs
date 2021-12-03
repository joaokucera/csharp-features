using System;

namespace CSharpFeatures.DoNotUseTheseFeatures
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var sum = i + j;
                    if (sum == 50)
                    {
                        goto End;
                    }
                }
            }
            
            Console.WriteLine("End of Loop");
            
            End:
            Console.WriteLine("End");
        }
    }
}