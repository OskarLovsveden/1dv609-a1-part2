namespace Model
{
    public class Song : ISong
    {
        private IArtist _artist;
        private ITitle _title;
        private ILyric _lyric;

        public Song(IArtist artist, ITitle title, ILyric lyric)
        {
            _artist = artist;
            _title = title;
            _lyric = lyric;
        }

        public string GetArtistName()
        {
            return _artist.Name;
        }

        public string GetSongLyrics()
        {
            return _lyric.LyricText;
        }

        public string GetSongTitle()
        {
            return _title.Name;
        }
    }
}