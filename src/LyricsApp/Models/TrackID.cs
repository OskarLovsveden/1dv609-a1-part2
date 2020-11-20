using System;
namespace Model
{
    public class TrackID
    {
        private string _trackID;

        public string ID
        {
            get => _trackID;
            set => _trackID = value;
        }

        public TrackID(string trackID)
        {
            ID = trackID;
        }

    }
}