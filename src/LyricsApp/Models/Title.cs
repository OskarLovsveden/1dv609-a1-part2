using System;

namespace Model
{
    public class Title : ITitle
    {
        private string titleName;

        public string TitleName
        {
            get => titleName;
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

                titleName = value;
            }
        }

        public Title(string titleName)
        {
            TitleName = titleName;
        }

    }
}