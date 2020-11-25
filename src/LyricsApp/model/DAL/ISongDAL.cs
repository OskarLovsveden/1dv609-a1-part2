using System.Threading.Tasks;

namespace Model.DAL
{
    public interface ISongDAL
    {
        Task<Song> GetSong(IArtist artist, ITitle songTitle);
    }
}