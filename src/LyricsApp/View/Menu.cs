using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using View.utils;
namespace View
{
    public class Menu
    {
        private IPrompt _prompt;
        private List<string> _menuItems = new List<string> { "Find Lyric", "Quit" };
        private string _promptArtistMessage = "Enter Artist Name";
        private string _promptSongTitle = "Enter Song Title";
        public Menu(IPrompt prompt)
        {
            _prompt = prompt;
        }

        public MenuOption ShowMainMenuGetUserSelection()
        {
            string menuItems = String.Join("\n", (_menuItems.Select((item, index) => $"{index + 1}: {item}")));

            int selection;
            bool inputWasValid = Int32.TryParse(_prompt.PromptQuestion(menuItems), out selection);

            if (inputWasValid == false)
            {
                return MenuOption.ShowMenu;
            }

            return (MenuOption)selection;
        }

        public IArtist GetArtist()
        {
            string artistName = _prompt.PromptQuestion(_promptArtistMessage);
            return new Artist(artistName);
        }

        public ITitle GetSongTitle()
        {
            string songTitle = _prompt.PromptQuestion(_promptSongTitle);
            return new Title(songTitle);
        }
    }
}