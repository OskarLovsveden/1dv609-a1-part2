using System;
using System.Collections.Generic;
using View.utils;
namespace View
{
    public class Menu
    {
        private IConsoleWrapper _consoleWrapper;
        private List<string> _menuItems = new List<string> { "Find Lyric", "Quit" };
        public Menu(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public void ShowMainMenu()
        {
            throw new NotImplementedException();
        }
    }
}