using System.Net.Http;
using System.Threading.Tasks;
using Config;
using CustomException;
using Newtonsoft.Json.Linq;

namespace Model.DAL
{
    public class TrackDAL : ITrackDAL
    {
        private readonly string getTrackURL = "matcher.track.get";
        private IFetch _fetch;
        private Settings settings = new Settings();

        public TrackDAL(IFetch fetch)
        {
            _fetch = fetch;
        }


        public async Task<TrackID> GetTrack(IArtist artist, ITitle title)
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
            return new TrackID(trackID);
        }
    }
}