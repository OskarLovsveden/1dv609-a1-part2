using System;

namespace Model
{
    public class Artist : IArtist
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException();
                }

                _name = value;
            }
        }

        public Artist(string name)
        {
            Name = name;
        }
    }
}