using System;
using Abstraction;

namespace Loggers
{
    public class ConsoleLogger :ILog
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Info: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
