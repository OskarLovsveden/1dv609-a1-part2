using Xunit;
using Moq;
using View;
using View.utils;

namespace LyricsAppTests
{
    public class MenuTests
    {
        [Fact]
        public void ShowMainMenu_DisplaysMenuItems()
        {
            string fakeMenuItems = GetFakeMainMenuItems();
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();

            Menu sut = new Menu(mockConsole.Object);
            sut.ShowMainMenu();

            mockConsole.Verify(c => c.WriteLine(fakeMenuItems));
        }

        [Fact]
        public void ShowPromptSongName_DisplaysMenuItems()
        {
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();

            Menu sut = new Menu(mockConsole.Object);
            sut.GetUserInput();

            mockConsole.Verify(c => c.ReadLine());
        }

        public string GetFakeMainMenuItems()
        {
            return "1: Find Lyric\n2: Quit\n";
        }
    }
}