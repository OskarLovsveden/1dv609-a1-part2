using System;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class TitleTests
    {

        [Fact]
        public void GetTitle_Name_ReturnsTheSetName()
        {
            string input = "Song Title";

            Title sut = new Title(input);

            string expected = input;
            string actual = sut.TitleName;

            Assert.Equal(expected, actual);
        }
    }
}