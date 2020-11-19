using System;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class TitleTests
    {
        [Fact]
        public void SetTitleName_EmptyString_ThrowsArgumentException()
        {
            string input = "";
            Assert.Throws<ArgumentException>(() => new Title(input));
        }

        [Fact]
        public void SetName_StringLengthOverHundredCharacters_ThrowsArgumentOutOfRangeException()
        {
            string input = new string('A', 101);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Title(input));
        }

        [Fact]
        public void GetTitleName_Name_ReturnsTheSetName()
        {
            string input = "Song Title";

            Title sut = new Title(input);

            string expected = input;
            string actual = sut.TitleName;

            Assert.Equal(expected, actual);
        }
    }
}