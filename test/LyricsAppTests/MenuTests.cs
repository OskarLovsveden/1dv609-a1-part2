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
            Mock<IConsoleWrapper> mockConsole = GetConsoleMock();
            Menu sut = GetSystemUnderTest(mockConsole);

            string fakeMenuItems = GetFakeMainMenuItems();

            sut.ShowMainMenu();

            mockConsole.Verify(c => c.WriteLine(fakeMenuItems));
        }

        [Fact]
        public void GetUserInput_ReturnsUserInput()
        {
            Mock<IConsoleWrapper> mockConsole = GetConsoleMock();
            Menu sut = GetSystemUnderTest(mockConsole);

            sut.GetUserInput();

            mockConsole.Verify(c => c.ReadLine());
        }

        [Fact]
        public void PromptArtistName_ReturnsNewIArtist()
        {
            string input = "ABBA";
            Mock<IArtist> mockArtist = new Mock<IArtist>();
            mockArtist.Setup(a => a.Name).Returns(input);
            Mock<IConsoleWrapper> mockConsole = GetConsoleMock();
            mockConsole.Setup(c => c.ReadLine()).Returns(input);

            Menu sut = GetSystemUnderTest(mockConsole);

            IArtist expected = mockArtist.Object;
            IArtist actual = sut.PromptArtistName();

            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void PromptArtistName_ShouldCallWriteLine()
        {
            string input = "ABBA";

            Mock<IConsoleWrapper> mockConsole = GetConsoleMock();
            Menu sut = GetSystemUnderTest(mockConsole);

            sut.PromptArtistName();

            mockConsole.Verify(c => c.WriteLine(input));
        }

        [Fact]
        public void PromptArtistName_ShouldCallWrite()
        {
            string input = ">";

            Mock<IConsoleWrapper> mockConsole = GetConsoleMock();
            Menu sut = GetSystemUnderTest(mockConsole);

            sut.PromptArtistName();

            mockConsole.Verify(c => c.Write(input));
        }

        [Fact]
        public void PromptArtistName_ShouldCallReadLine()
        {
            Mock<IConsoleWrapper> mockConsole = GetConsoleMock();
            Menu sut = GetSystemUnderTest(mockConsole);

            sut.PromptArtistName();

            mockConsole.Verify(c => c.ReadLine());
        }


        public string GetFakeMainMenuItems()
        {
            return "1: Find Lyric\n2: Quit";
        }

        private Menu GetSystemUnderTest(Mock<IConsoleWrapper> console)
        {
            return new Menu(console.Object);
        }

        private Mock<IConsoleWrapper> GetConsoleMock()
        {
            return new Mock<IConsoleWrapper>();
        }
    }
}