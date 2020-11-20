using System;
namespace Model
{
    public class Track
    {
        private string _id;

        public string ID
        {
            get => _id;
            private set => _id = value;
        }

        public Track(string id)
        {
            ID = id;
        }

    }
}