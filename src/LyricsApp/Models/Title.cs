using System;

namespace Model
{
    public class Title : ITitle
    {
        private string titleName;

        public string TitleName
        {
            get => titleName;
            private set => titleName = value;
        }

        public Title(string titleName)
        {
            TitleName = titleName;
        }

    }
}