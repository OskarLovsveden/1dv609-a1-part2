using System;
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
    }
}