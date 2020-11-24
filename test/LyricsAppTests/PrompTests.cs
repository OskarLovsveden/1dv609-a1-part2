using Xunit;
using Moq;
using View.utils;

namespace LyricsAppTests
{
    public class PrompTests
    {
        [Fact]
        public void PromptQuestion_PromptMessage_ReturnsUserInput()
        {
            string input = "Test";
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();
            mockConsole.Setup(c => c.ReadLine()).Returns(input);

            Prompt sut = new Prompt(mockConsole.Object);

            string expected = input;
            string actual = sut.PromptQuestion(input);

            Assert.Equal(expected, actual);
        }
    }
}