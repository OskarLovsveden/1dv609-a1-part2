using System;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class AppStateTests
    {
        [Fact]
        public void soemthing()
        {
            IAppState sut = new AppState();
            sut.Exit();

            bool expected = false;
            bool actual = sut.ShouldRun;

            Assert.Equal(expected, actual);
        }
    }
}