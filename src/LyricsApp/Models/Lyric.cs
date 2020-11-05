using System;
using System.Text.RegularExpressions;
namespace Model
{
    public class Lyric
    {
        private string _lyricText;
        public Lyric(string lyricText)
        {
            _lyricText = lyricText;
        }

        public int CountAllWords()
        {
            Regex r = new Regex(@"(?!'.*')\b[\w'-]+\b");
            return r.Matches(_lyricText).Count;
        }

        public int CountOccurrencesOfWord(string toBeCounted)
        {
            string toBeCountedStripped = toBeCounted.Replace("'", "");
            string lyricsTextStripped = _lyricText.Replace("'", "");
            return Regex.Matches(lyricsTextStripped, "\\b" + Regex.Escape(toBeCountedStripped) + "\\b", RegexOptions.IgnoreCase).Count;
        }
    }
}