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
        public string getArtistName()
        {
            throw new System.NotImplementedException();
        }

        public string getSongLyrics()
        {
            throw new System.NotImplementedException();
        }

        public string getSongTitle()
        {
            throw new System.NotImplementedException();
        }
    }
}