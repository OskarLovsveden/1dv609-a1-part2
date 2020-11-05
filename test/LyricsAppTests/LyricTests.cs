using Xunit;
using Model;

namespace LyricsAppTests
{
    public class LyricTests
    {
        [Theory]
        [InlineData("Never gonna give you up.", 5)]
        [InlineData("We're no strangers to love. You know the rules and so do I", 13)]
        public void ShouldReturnAmountOfWordsInLyricText(string lyricText, int wordAmount)
        {
            Lyric sut = new Lyric(lyricText);

            int actual = sut.CountAllWords();
            int expected = wordAmount;

            Assert.Equal(actual, expected);
        }
    }
}
