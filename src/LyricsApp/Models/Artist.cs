using System;

namespace Model
{
    public class Artist : IArtist
    {
        private string _name;
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Artist(string name)
        {
            Name = name;
        }
    }
}