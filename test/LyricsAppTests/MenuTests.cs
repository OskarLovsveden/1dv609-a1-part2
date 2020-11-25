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
        public void ShowMainMenuGetUserSelectio_ReturnsCorrectEnum()
        {
            string input = "1";

            Menu sut = GetSystemUnderTest(input);

            MenuOption expected = MenuOption.SelectSong;
            MenuOption actual = sut.ShowMainMenuGetUserSelection();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("ABBA")]
        [InlineData("Metallica")]
        public void PromptArtistName_ReturnsNewIArtist(string input)
        {
            Menu sut = GetSystemUnderTest(input);

            string expected = input;
            string actual = sut.GetArtist().Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Waterloo")]
        [InlineData("Nothing else matters")]
        public void PromptSongTitle_ReturnsNewITitle(string input)
        {
            Menu sut = GetSystemUnderTest(input);

            string expected = input;
            string actual = sut.GetSongTitle().Name;

            Assert.Equal(expected, actual);
        }

        private Menu GetSystemUnderTest(string input)
        {
            Mock<IPrompt> mockPrompt = new Mock<IPrompt>();
            mockPrompt.Setup(p => p.PromptQuestion(It.IsAny<string>())).Returns(input);
            return new Menu(mockPrompt.Object);
        }
    }
}