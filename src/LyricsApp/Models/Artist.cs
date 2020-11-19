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
            if (name.Length < 1)
            {
                throw new ArgumentException();
            }
            Name = name;
        }
    }
}