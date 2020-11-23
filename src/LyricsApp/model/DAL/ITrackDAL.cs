using System.Threading.Tasks;

namespace Model.DAL
{
    public interface ITrackDAL
    {
        Task<TrackID> GetTrack(IArtist artist, ITitle title);
    }
}