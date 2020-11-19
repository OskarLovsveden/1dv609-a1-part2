using System;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class ArtistTests
    {
        [Fact]
        public void SetName_EmptyString_ThrowsArgumentException()
        {
            string input = "";
            Assert.Throws<ArgumentException>(() => new Artist(input));
        }

        [Fact]
        public void SetName_StringLengthOverFiftyCharacters_ThrowsArgumentOutOfRangeException()
        {
            string input = new string('*', 51);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Artist(input));
        }

        [Fact]
        public void GetName_Name_ReturnsTheSetName()
        {
            string input = "Artist Name";

            Artist sut = new Artist(input);

            string expected = input;
            string actual = sut.Name;

            Assert.Equal(expected, actual);
        }
    }
}