using System.Threading.Tasks;

namespace Model.DAL
{
    public interface ITrackDAL
    {
        Task<ITrackID> GetTrack(IArtist artist, ITitle title);
    }
}