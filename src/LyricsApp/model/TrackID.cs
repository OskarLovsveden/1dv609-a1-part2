namespace Model
{
    public class TrackID : ITrackID
    {
        private string _id;

        public string Value
        {
            get => _id;
            private set => _id = value;
        }

        public TrackID(string id)
        {
            Value = id;
        }
    }
}