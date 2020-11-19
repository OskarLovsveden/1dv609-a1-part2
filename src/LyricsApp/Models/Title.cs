using System;

namespace Model
{
    public class Title : ITitle
    {
        public Title(string titleName)
        {
            TitleName = titleName;
        }

        public string TitleName
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }
    }
}