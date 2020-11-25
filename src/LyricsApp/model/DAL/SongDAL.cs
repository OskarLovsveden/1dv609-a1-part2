using System.Net;
using CustomException;
using System.Net.Http;
using System.Threading.Tasks;
using Config;
using Newtonsoft.Json.Linq;
using System;

namespace Model.DAL
{
    public class SongDAL : ISongDAL
    {
        private readonly string getLyricURL = "track.lyrics.get";
        private Settings settings = new Settings();

        private ITrackDAL _trackDAL;
        private IFetch _fetch;

        public SongDAL(IFetch fetch, ITrackDAL trackDAL)
        {
            _fetch = fetch;
            _trackDAL = trackDAL;
        }

        public async Task<Song> GetSong(IArtist artist, ITitle songTitle)
        {
            ITrackID trackID = await _trackDAL.GetTrack(artist, songTitle);
            string url = $"{settings.BaseURL}{getLyricURL}?format=jsonp&callback=callback&track_id={trackID}&apikey={settings.API_KEY}";

            HttpResponseMessage responseMessage = await _fetch.GetAsync(url);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new SongNotFoundException();
            }

            string response = await responseMessage.Content.ReadAsStringAsync();
            response = response.Replace("callback(", "");
            response = response.Replace(");", "");
            JObject responseJson = JObject.Parse(response);

            string lyricsText = (string)responseJson["message"]["body"]["lyrics"]["lyrics_body"];
            Lyric lyrics = new Lyric(lyricsText);

            return new Song(artist, songTitle, lyrics);
        }
    }
}