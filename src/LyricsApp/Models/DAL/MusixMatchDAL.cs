using System;
using Config;
namespace Model.DAL
{
    public class MusixMatchDAL
    {
        private readonly string getLyricURL = "matcher.lyrics.get";
        private Settings settings = new Settings();
        private IFetch _fetch;

        public MusixMatchDAL(IFetch fetch)
        {
            _fetch = fetch;
        }

        public Track GetTrack(IArtist artist, ITitle title)
        {
            throw new NotImplementedException();
        }
    }
}