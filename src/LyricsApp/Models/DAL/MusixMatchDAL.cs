using System.Net.Http;
using System.Threading.Tasks;
using Config;
using Newtonsoft.Json.Linq;

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

        public async Task<Track> GetTrack(IArtist artist, ITitle title)
        {
            string url = $"{settings.BaseURL}{getLyricURL}?format=jsonp&callback=callback&q_artist={artist.Name}&q_track={title.Name}&apikey={settings.API_KEY}";

            HttpResponseMessage responseMessage = await _fetch.GetAsync(url);

            string response = await responseMessage.Content.ReadAsStringAsync();
            response = response.Replace("callback(", "");
            response = response.Replace(");", "");
            JObject responseJson = JObject.Parse(response);

            string trackID = (string)responseJson["message"]["body"]["track"]["track_id"];
            return new Track(trackID);
        }
    }
}