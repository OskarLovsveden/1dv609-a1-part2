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

            mockConsole.Setup(console => console.WriteLine(fakeMenuItems)).Callback(() => { Console.WriteLine(fakeMenuItems); });

            Menu sut = new Menu(mockConsole.Object);


            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                sut.ShowMainMenu();

                string expected = fakeMenuItems;
                string actual = sw.ToString();

                Assert.Equal(expected, actual);
            }
        }


        public string GetFakeMenuItems()
        {
            return "1: Find Lyric\n2: Quit";
        }
    }
}