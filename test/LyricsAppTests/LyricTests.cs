using System;
using Xunit;
using Model;

namespace LyricsAppTests
{
    public class LyricTests
    {
        [Theory]
        [InlineData("Aa Bb Cc", 3)]
        public void CountAllWords_OnlyWords_ReturnAmountOfWords(string input, int expected)
        {
            Assert_CountAllWords(input, expected);
        }

        [Theory]
        [InlineData("Aa - . & / ! ¤ # Bb Cc", 3)]
        [InlineData("Aa\rBb\nCc", 3)]
        public void CountAllWords_WordsAndSpecialCharacters_ReturnAmountOfWords(string input, int expected)
        {
            Assert_CountAllWords(input, expected);
        }

        [Theory]
        [InlineData("Aa-Bb-Cc", 1)]
        [InlineData("Aa-Bb-Cc a'b", 2)]
        public void CountAllWords_WordsWithSeparators_ReturnAmountOfWords(string input, int expected)
        {
            Assert_CountAllWords(input, expected);
        }

        private void Assert_CountAllWords(string input, int expected)
        {
            Lyric sut = new Lyric(input);

            int actual = sut.CountAllWords();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Aa bb Aa bb", "bb", 2)]
        [InlineData("Aa bb aa bb", "aa", 2)]
        [InlineData("Aa bb aa bb aa'bb", "aa", 2)]
        public void WordFrequency_Word_ReturnsWordFrequencyCaseInsensitive(string inputText, string inputWord, int expected)
        {
            Assert_WordFrequency(inputText, inputWord, expected);
        }

        [Theory]
        [InlineData("Aa bb aa bb aa-bb", "aa-bb", 1)]
        [InlineData("Aa bb aab bb aa'b", "aa'b", 2)]
        public void WordFrequency_Word_ReturnsWordFrequencyOfWordWithOrWithoutSeparator(string inputText, string inputWord, int expected)
        {
            Assert_WordFrequency(inputText, inputWord, expected);
        }

        [Theory]
        [InlineData("Aa (bb) Aa bb {bb}", "bb", 3)]
        [InlineData("Aa \"bb\" Aa bb", "bb", 2)]
        public void WordFrequency_Word_ReturnsWordFrequencyOfWordIgnoringWordWrappers(string inputText, string inputWord, int expected)
        {
            Assert_WordFrequency(inputText, inputWord, expected);
        }

        [Theory]
        [InlineData("Aa bb aa\raa", "aa", 3)]
        [InlineData("Aa bb aa\taa", "aa", 3)]
        [InlineData("Aa bb aa\naa", "aa", 3)]
        public void WordFrequency_Word_ReturnsWordFrequencyOfWordIgnoringEscapeSequence(string inputText, string inputWord, int expected)
        {
            Assert_WordFrequency(inputText, inputWord, expected);
        }

        [Theory]
        [InlineData("Ää Åå ää Öö", "ää", 2)]
        public void WordFrequency_Word_ReturnsWordFrequencyOfWordWithSwedishLetters(string inputText, string inputWord, int expected)
        {
            Assert_WordFrequency(inputText, inputWord, expected);
        }

        [Fact]
        public void WordFrequency_EmptyString_ThrowsArgumentException()
        {
            Lyric sut = new Lyric("Aa bb cc");
            string input = "";

            Assert.Throws<ArgumentException>(() => sut.WordFrequency(input));
        }

        private void Assert_WordFrequency(string inputText, string inputWord, int expected)
        {
            Lyric sut = new Lyric(inputText);

            int actual = sut.WordFrequency(inputWord);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Lyric_Constructor_EmptyString_ThrowsArgumentException(string input)
        {
            Assert.Throws<ArgumentException>(() => new Lyric(input));
        }

        [Theory]
        [InlineData("", "Lyrictext can not be empty")]
        public void Lyric_Constructor_EmptyString_ThrowsArgumentExceptionWithMessage(string input, string expected)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Lyric(input));

            string actual = exception.Message;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Aa Bb Cc")]
        public void LyricGet_LyricText_ReturnsSameStringThatWasSet(string input)
        {
            Lyric sut = new Lyric(input);

            string expected = input;
            string actual = sut.LyricText;

            Assert.Equal(expected, actual);
        }
    }
}
