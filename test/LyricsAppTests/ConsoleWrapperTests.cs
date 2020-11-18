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
        [InlineData("World Hello")]
        public void Write_TextToWrite_WritesTextToConsole(string input)
        {
            ConsoleWrapper sut = new ConsoleWrapper();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sut.Write(input);

                string expected = input;
                string actual = sw.ToString();

                Assert.Equal(expected, actual);
            }

            ResetConsole();
        }

        [Theory]
        [InlineData("Hello World")]
        [InlineData("World Hello")]
        public void WriteLine_TextToWrite_WritesTextToConsole(string input)
        {
            AssertWriteToConsole(input);
        }

        private void AssertWriteToConsole(string input)
        {
            ConsoleWrapper sut = new ConsoleWrapper();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sut.WriteLine(input);

                string expected = input;
                string actual = sw.ToString().Trim();

                Assert.Equal(expected, actual);
            }

            ResetConsole();
        }

        [Theory]
        [InlineData("Hello World")]
        [InlineData("World Hello")]
        public void ReadLine_InputForConsole_ReturnsInputFromConsole(string input)
        {
            ConsoleWrapper sut = new ConsoleWrapper();

            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);

                string expected = input;
                string actual = sut.ReadLine();

                Assert.Equal(expected, actual);
            }
        }

        private void ResetConsole()
        {
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }
    }
}