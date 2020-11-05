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

            int expected = wordAmount;
            int actual = sut.CountAllWords();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Black and yellow, black and yellow Black and yellow, black and yellow", 4, "yellow")]
        [InlineData("It's raining tacos From out of the sky. Tacos!" +
        " No need to ask why. Just open your mouth and close your eyes. It's raining tacos", 3, "tacos")]
        [InlineData("Cheese ham, hamster tuna cat dog hammer.", 1, "ham")]
        public void ShouldReturnOccurrencesOfWordInLyricText(string lyricText, int occurrences, string word)
        {
            Lyric sut = new Lyric(lyricText);

            int expected = occurrences;
            int actual = sut.CountOccurrencesOfWord(word);

            Assert.Equal(expected, actual);
        }
    }
}
