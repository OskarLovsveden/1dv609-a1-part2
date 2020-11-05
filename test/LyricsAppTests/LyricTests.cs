using Xunit;
using Model;

namespace LyricsAppTests
{
    public class LyricTests
    {
        [Theory]
        [InlineData("We're no strangers to love. You know the rules and so do I", 13)]
        [InlineData("and both shall row - my love and I", 8)]
        [InlineData("love & I", 2)]
        [InlineData("Oh-la-la \n", 1)]
        [InlineData("", 0)]
        public void ShouldReturnAmountOfWordsInLyricText(string lyricText, int wordAmount)
        {
            Lyric sut = new Lyric(lyricText);

            int actual = sut.CountAllWords();
            int expected = wordAmount;

            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("Black and yellow, black and yellow Black and yellow, black and yellow", 4, "yellow")]
        public void ShouldReturnOccurrencesOfWordInLyricText(string lyricText, int occurrences, string word)
        {
            Lyric sut = new Lyric(lyricText);

            int actual = sut.CountOccurrencesOfWord(word);
            int expected = occurrences;

            Assert.Equal(actual, expected);
        }
    }
}
