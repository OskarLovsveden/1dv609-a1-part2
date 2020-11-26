using Xunit;
using Model;

namespace LyricsAppTests
{
    public class AppStateTests
    {
        [Fact]
        public void Exit_ShouldSetShouldRunToFalse()
        {
            IAppState sut = new AppState();
            sut.Exit();

            bool expected = false;
            bool actual = sut.ShouldRun;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(MenuOption.ShowMenu)]
        public void Set_MenuOption_ShouldSetCurrentValue(MenuOption input)
        {
            IAppState sut = new AppState();
            sut.Current = input;

            MenuOption expected = input;
            MenuOption actual = sut.Current;

            Assert.Equal(expected, actual);
        }
    }
}