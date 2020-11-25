using System;
using System.Text.RegularExpressions;

namespace Model
{
    public class Lyric : ILyric
    {
        private string _lyricText;

        private string _wordPattern = @"(?!'.*')\b[\w'-]+\b";
        public string LyricText
        {
            get => _lyricText;

            private set
            {
                if (!Regex.IsMatch(Regex.Escape(value), @"\w"))
                {
                    throw new ArgumentException("Lyrictext can not be empty");
                }
                _lyricText = value;
            }
        }
        public Lyric(string lyricText)
        {
            LyricText = lyricText;
        }

        public int CountAllWords()
        {
            return Regex.Matches(_lyricText, _wordPattern).Count;
        }

        public int WordFrequency(string toBeCounted)
        {
            if (!Regex.IsMatch(toBeCounted, _wordPattern))
            {
                throw new ArgumentException();
            }

            return CountWordFrequency(toBeCounted);
        }

        private int CountWordFrequency(string toBeCounted)
        {
            string pattern = "\\b" + Regex.Escape(StripApostrophes(toBeCounted)) + "\\b";

            return Regex.Matches(StripApostrophes(_lyricText), pattern, RegexOptions.IgnoreCase).Count;
        }

        private string StripApostrophes(string toBeStripped)
        {
            return toBeStripped.Replace("'", "");
        }
    }
}