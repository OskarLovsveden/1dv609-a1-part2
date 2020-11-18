using System;

namespace Model
{
    public class Artist : IArtist
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public Artist(string name)
        {
            Name = name;
        }
    }
}