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
            Mock<IArtist> mockArtist = GetNewMockArtist();
            Mock<ITitle> mockTitle = GetNewMockTitle();
            Mock<ILyric> mockLyric = GetNewMockLyric();

            mockArtist.Setup(artist => artist.Name).Returns(input);

            Song sut = new Song(mockArtist.Object, mockTitle.Object, mockLyric.Object);

            string expected = input;
            string actual = sut.getArtistName();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSongTitle_ShouldReturnSongTitle()
        {
            string input = "Song Title";
            Mock<IArtist> mockArtist = GetNewMockArtist();
            Mock<ITitle> mockTitle = GetNewMockTitle();
            Mock<ILyric> mockLyric = GetNewMockLyric();

            mockTitle.Setup(title => title.TitleName).Returns(input);

            Song sut = new Song(mockArtist.Object, mockTitle.Object, mockLyric.Object);

            string expected = input;
            string actual = sut.getSongTitle();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSongLyrics_ShouldReturnSongLyrics()
        {
            string input = new string('*', 100);
            Mock<IArtist> mockArtist = GetNewMockArtist();
            Mock<ITitle> mockTitle = GetNewMockTitle();
            Mock<ILyric> mockLyric = GetNewMockLyric();

            mockLyric.Setup(lyric => lyric.LyricText).Returns(input);

            Song sut = new Song(mockArtist.Object, mockTitle.Object, mockLyric.Object);

            string expected = input;
            string actual = sut.getSongLyrics();

            Assert.Equal(expected, actual);
        }

        private Mock<IArtist> GetNewMockArtist() => new Mock<IArtist>();
        private Mock<ITitle> GetNewMockTitle() => new Mock<ITitle>();
        private Mock<ILyric> GetNewMockLyric() => new Mock<ILyric>();
    }
}