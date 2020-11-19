using System;

namespace Model
{
    public class Title : ITitle
    {
        private string titleName;
        public Title(string titleName)
        {
            TitleName = titleName;
        }

        public string TitleName
        {
            get => titleName;
            private set => titleName = value;
        }
    }
}