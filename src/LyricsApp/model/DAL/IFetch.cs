using System.Net.Http;
using System.Threading.Tasks;

namespace Model.DAL
{
    public interface IFetch
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}