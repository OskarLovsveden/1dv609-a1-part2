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

        [Fact]
        public void PromptQuestion_ShouldCallReadLine()
        {
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();
            Prompt sut = new Prompt(mockConsole.Object);

            sut.PromptQuestion(It.IsAny<string>());

            mockConsole.Verify(c => c.ReadLine());
        }

        [Fact]
        public void PromptQuestion_ShouldCallWriteLine()
        {
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();
            Prompt sut = new Prompt(mockConsole.Object);

            sut.PromptQuestion(It.IsAny<string>());

            mockConsole.Verify(c => c.WriteLine(It.IsAny<string>()));
        }

        [Fact]
        public void PromptQuestion_ShouldCallWrite()
        {
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();
            Prompt sut = new Prompt(mockConsole.Object);

            sut.PromptQuestion(It.IsAny<string>());

            mockConsole.Verify(c => c.Write(It.IsAny<string>()));
        }
    }
}