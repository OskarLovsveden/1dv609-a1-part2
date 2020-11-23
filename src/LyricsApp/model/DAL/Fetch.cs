using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class Fetch : IFetch
    {
        private HttpClient _client;

        public Fetch(HttpClient client)
        {
            _client = client;
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }
    }
}