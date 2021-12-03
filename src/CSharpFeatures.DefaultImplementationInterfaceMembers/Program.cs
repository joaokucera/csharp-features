using System;

namespace CSharpFeatures.DefaultImplementationInterfaceMembers
{
    /// <summary>
    /// https://github.com/dotnet/csharplang/issues/288
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.Log(LogLevel.Debug, $"Application started at {DateTime.Now:F}");
            logger.Log(new Exception("Something went wrong"));
        }
    }

    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }
    
    public interface ILogger
    {
        void Log(LogLevel level, string message);

        // void Log(Exception exception);
        
        // void Log(Exception exception)
        // {
        //     Log(LogLevel.Error, exception.ToString());
        // }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            Console.ForegroundColor = level switch
            {
                LogLevel.Debug => ConsoleColor.Cyan,
                LogLevel.Info => ConsoleColor.White,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
            
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // public void Log(Exception exception)
        // {
        //     Log(LogLevel.Error, exception.ToString());
        // }
    }

    /// <summary>
    /// before C# 8.0
    /// </summary>
    public static class LoggerExtensions
    {
        public static void Log(this ILogger logger, Exception exception)
        {
            logger.Log(LogLevel.Error, exception.ToString());
        }
    }
}