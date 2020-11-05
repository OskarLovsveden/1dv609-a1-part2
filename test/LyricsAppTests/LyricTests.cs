using Xunit;
using Model;

namespace LyricsAppTests
{
    public class LyricTests
    {
        [Theory]
        [InlineData("Never gonna give you up.", 5)]
        [InlineData("We're no strangers to love. You know the rules and so do I", 13)]
        [InlineData("I just wanna tell you how I'm feeling. Gotta make you understand", 12)]
        [InlineData("and both shall row - my love and I", 8)]
        public void ShouldReturnAmountOfWordsInLyricText(string lyricText, int wordAmount)
        {
            Lyric sut = new Lyric(lyricText);

            int actual = sut.CountAllWords();
            int expected = wordAmount;

            Assert.Equal(actual, expected);
        }
    }
}
