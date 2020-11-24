using System;
using Xunit;
using Moq;
using View;
using View.utils;
using System.IO;

namespace LyricsAppTests
{
    public class MenuTests
    {
        [Fact]
        public void ShowMainMenu_DisplaysMenuItems()
        {
            string fakeMenuItems = GetFakeMenuItems();
            Mock<IConsoleWrapper> mockConsole = new Mock<IConsoleWrapper>();

            Menu sut = new Menu(mockConsole.Object);
            sut.ShowMainMenu();

            mockConsole.Verify(c => c.WriteLine(fakeMenuItems));
        }

        public string GetFakeMenuItems()
        {
            return "1: Find Lyric\n2: Quit\n";
        }
    }
}