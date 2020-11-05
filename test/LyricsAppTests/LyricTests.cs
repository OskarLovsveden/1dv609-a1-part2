using Xunit;
using Model;

namespace LyricsAppTests
{
    public class LyricTests
    {
        [Fact]
        public void ShouldReturnAmountOfWordsInLyricText()
        {
            Lyric sut = new Lyric("Never gonna give you up.");

            int actual = sut.CountAllWords();
            int expected = 5;

            Assert.Equal(actual, expected);
        }
    }
}
