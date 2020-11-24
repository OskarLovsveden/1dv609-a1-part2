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
            string mainMenuItems = "";

            for (int i = 0; i < _menuItems.Count; i++)
            {
                mainMenuItems += $"{i + 1}: {_menuItems[i]}\n";
            }

            _consoleWrapper.WriteLine(mainMenuItems);
        }

        public string GetUserInput()
        {
            return _consoleWrapper.ReadLine();
        }
    }
}