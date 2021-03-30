using B.Library;
using System;

namespace Boxer
{
    class Logger : ILogger
    {
        public void Debug(string text)
        {
            Console.WriteLine($"Information: {text}");
        }

        public void Error(string text)
        {
            Console.WriteLine($"Error: {text}");
        }

        public void Information(string text)
        {
            Console.WriteLine($"Information: {text}");
        }

        public void Warning(string text)
        {
            Console.WriteLine($"Warning: {text}");
        }
    }
}
