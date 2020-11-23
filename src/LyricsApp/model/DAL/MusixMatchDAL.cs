using System.Net;
using CustomException;
using System.Net.Http;
using System.Threading.Tasks;
using Config;
using Newtonsoft.Json.Linq;
using System;

namespace Model.DAL
{
    public class MusixMatchDAL
    {
        private readonly string getTrackURL = "matcher.track.get";
        private readonly string getLyricURL = "track.lyrics.get";
        private Settings settings = new Settings();
        private IFetch _fetch;

        public MusixMatchDAL(IFetch fetch)
        {
            _fetch = fetch;
        }

        public async Task<Track> GetTrack(IArtist artist, ITitle title)
        {
            string url = $"{settings.BaseURL}{getTrackURL}?format=jsonp&callback=callback&q_artist={artist.Name}&q_track={title.Name}&apikey={settings.API_KEY}";

            HttpResponseMessage responseMessage = await _fetch.GetAsync(url);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new TrackNotFoundException();
            }

            string response = await responseMessage.Content.ReadAsStringAsync();
            response = response.Replace("callback(", "");
            response = response.Replace(");", "");
            JObject responseJson = JObject.Parse(response);

            string trackID = (string)responseJson["message"]["body"]["track"]["track_id"];
            return new Track(trackID);
        }

        public async Task<Song> GetSong(string artistName, string songTitle, string trackID)
        {
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

            Artist artist = new Artist(artistName);
            Title title = new Title(songTitle);
            Lyric lyrics = new Lyric(lyricsText);

            return new Song(artist, title, lyrics);
        }
    }
}