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
        public Menu(IPrompt prompt)
        {
            _prompt = prompt;
        }

        public string ShowMainMenuGetUserSelection()
        {
            string menuItems = String.Join("\n", (_menuItems.Select((item, index) => $"{index + 1}: {item}")));
            return _prompt.PromptQuestion(menuItems);
        }

        public IArtist GetArtist()
        {
            string artistName = _prompt.PromptQuestion(_promptArtistMessage);
            return new Artist(artistName);
        }

        public ITitle GetSongTitle()
        {
            throw new NotImplementedException();
        }
    }
}