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