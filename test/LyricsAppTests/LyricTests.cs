using Xunit;
using Model;

namespace LyricsAppTests
{
    public class LyricTests
    {
        [Fact]
        public void ShouldReturnCountWordsInLyric()
        {
            Lyric sut = new Lyric("Never gonna give you up, never gonna let you down.");

            int actual = sut.CountAllWords();
            int expected = 10;

            Assert.Equal(actual, expected);
        }
    }
}
