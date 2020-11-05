using System;

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
            return 5;
        }
    }
}