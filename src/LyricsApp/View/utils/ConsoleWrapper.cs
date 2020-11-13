using System;
namespace View.utils
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string input)
        {
            Console.Write("Hello World");
        }

        public void WriteLine(string input)
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

    }
}