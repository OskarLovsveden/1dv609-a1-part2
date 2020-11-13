using System;
using Xunit;
using System.IO;
using View.utils;

namespace LyricsAppTests
{
    public class ConsoleWrapperTests
    {
        [Theory]
        [InlineData("Hello World")]
        public void Write_TextToWrite_WritesTextToConsole(string input)
        {
            ConsoleWrapper sut = new ConsoleWrapper();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sut.Write(input);

                string actual = sw.ToString();
                Assert.Equal(input, actual);

                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput); 
            }
        }
    }
}