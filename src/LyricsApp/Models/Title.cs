using System;

namespace Model
{
    public class Title : ITitle
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

                if (value.Length > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _name = value;
            }
        }

        public Title(string name)
        {
            Name = name;
        }

    }
}