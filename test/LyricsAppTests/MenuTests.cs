using Xunit;
using Moq;
using Model;
using View;
using View.utils;

namespace LyricsAppTests
{
    public class MenuTests
    {
        [Fact]
        public void ShowMainMenu_DisplaysMenuItems()
        {
            string input = "test";
            Mock<IPrompt> mockPrompt = GetMockPrompt();
            mockPrompt.Setup(p => p.PromptQuestion(It.IsAny<string>())).Returns(input);

            Menu sut = GetSystemUnderTest(mockPrompt);

            string expected = input;
            string actual = sut.ShowMainMenuGetUserSelection();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ABBA")]
        [InlineData("Metallica")]
        public void PromptArtistName_ReturnsNewIArtist(string input)
        {
            Mock<IPrompt> mockPrompt = GetMockPrompt();
            mockPrompt.Setup(p => p.PromptQuestion(It.IsAny<string>())).Returns(input);
            Menu sut = GetSystemUnderTest(mockPrompt);

            string expected = input;
            string actual = sut.GetArtist().Name;

            Assert.Equal(expected, actual);
        }

        private Menu GetSystemUnderTest(Mock<IPrompt> console)
        {
            return new Menu(console.Object);
        }

        private Mock<IPrompt> GetMockPrompt()
        {
            return new Mock<IPrompt>();
        }
    }
}