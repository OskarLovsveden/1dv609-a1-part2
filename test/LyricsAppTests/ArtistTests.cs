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
        public void SetName_StringLengthOverHundredCharacters_ThrowsArgumentOutOfRangeException()
        {
            string input = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit.  
            Proin malesuada tellus ac porttitor laoreet. Pellentesque condimentum tincidunt nunc,   
            vel consequat ligula eleifend in. Cras aliquet, tellus nec feugiat elementum, tortor   
            erat dapibus ante, eget molestie tortor diam eget libero. Ut fringilla leo eget rutrum  
            posuere. Etiam posuere accumsan libero, vel semper nisi eleifend at. Curabitur at eros  
            id elit pellentesque venenatis id et libero. Vestibulum sed nibh ultrices purus ultricies   
            porta. Nullam vel odio quam. Vivamus ut tincidunt lorem. Proin eget aliquet sem. Nullam enim  
            orci, condimentum a efficitur nec, iaculis aliquet augue. Sed ac elit ut dui ornare eleifend non.";

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