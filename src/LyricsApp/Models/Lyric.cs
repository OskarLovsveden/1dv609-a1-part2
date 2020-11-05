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
            int numberOfWords = 1;
            int increment = 0;

            while (increment <= _lyricText.Length -1)
            {
                if((_lyricText[increment]  == ' ' || _lyricText[increment] == '\n' || _lyricText[increment] == '\t') && _lyricText[increment -1] != '-') {
                    numberOfWords++;
                }
                increment++;
            }
            return numberOfWords;
        }
    }
}