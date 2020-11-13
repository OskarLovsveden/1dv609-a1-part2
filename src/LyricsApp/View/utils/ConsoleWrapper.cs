using System;
namespace View.utils
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

    }
}