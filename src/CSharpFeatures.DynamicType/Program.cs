using System;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using IronPython.Hosting;
using Newtonsoft.Json;

namespace CSharpFeatures.DynamicType
{
    /// <summary>
    /// Introduced in C# 4.0 (2010) + with DLR (dynamic language runtime) - windows bound
    /// python, javascript?
    /// </summary>
    public class Program
    {
        static void Main_Samples(string[] args)
        {
            dynamic calculator = GetCalculator();
            calculator.MethodName();

            var addResult = calculator.Add(10, 20);
            Console.WriteLine($"The result was {addResult}");

            var multipleResult = calculator.Multiply(10, 20);
            Console.WriteLine($"The result was {multipleResult}");

            // NOT POSSIBLE
            // dynamic dynamic = new dynamic();

            // POSSIBLE
            dynamic expandoObject = new ExpandoObject();
            expandoObject.Name = "Joao";
            Console.WriteLine($"The result was {expandoObject.Name}");

            // PYTHON
            dynamic python = Python.CreateRuntime().UseFile("./calculator.py");
            var pythonCalculator = python.Calculator;
            int sum = pythonCalculator.add(50, 10);
            Console.WriteLine($"The result from python was {sum}");
        }

        static void Main_Bench(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
        }

        // /// <summary>
        // /// No DTO, POCO, etc 
        // /// </summary>
        // static async Task Main(string[] args)
        // {
        //     var httpClient = new HttpClient
        //     {
        //         DefaultRequestHeaders =
        //         {
        //             Accept = {new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")},
        //             UserAgent = {ProductInfoHeaderValue.Parse("request")}
        //         }
        //     };
        //
        //     var responseText = await httpClient.GetStringAsync("https://api.github.com/users/joaokucera");
        //     dynamic? response = JsonConvert.DeserializeObject(responseText);
        //
        //     Console.WriteLine($"Joao's Github follower are: {response.followers}");
        // }

        private static dynamic GetCalculator()
        {
            return new Calculator();
        }
    }

    public class Calculator
    {
        public int Add(int first, int second)
        {
            return first + second;
        }
    }
}