using Moq;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class SongTests
    {
        [Fact]
        public void GetArtistName_ShouldReturnArtistName()
        {
            string input = "Artist Name";
            Mock<IArtist> mockArtist = new Mock<IArtist>();
            mockArtist.Setup(artist => artist.Name).Returns(input);

            Mock<ITitle> mockTitle = new Mock<ITitle>();
            Mock<ILyric> mockLyric = new Mock<ILyric>();

            Song sut = new Song(mockArtist.Object, mockTitle.Object, mockLyric.Object);

            string expected = input;
            string actual = sut.getArtistName();

            Assert.Equal(expected, actual);
        }
    }
}