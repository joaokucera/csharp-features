namespace CSharpFeatures.ConstantInterpolatedStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    public static class Servers
    {
        private const string ApiBase = "/api";
        private const string Base = ApiBase + "/library";
        
        // before...
        private static readonly string CSharp9Sample1 = Base + "/{id:guid}";
        private static readonly string CSharp9Sample2 = $"{Base}/{{id:guid}}";
        // C# 10
        private const string CSharp10Sample1 = Base + "/{id:guid}";
        private const string CSharp10Sample2 = $"{Base}/{{id:guid}}";
    }
}