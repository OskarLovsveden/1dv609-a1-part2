using System;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class ArtistTests
    {
        [Fact]
        public void GetName_Name_ReturnsTheSetName()
        {
            string input = "Cool guy";

            Artist sut = new Artist(input);

            string expected = input;
            string actual = sut.Name;

            Assert.Equal(expected, actual);
        }
    }
}