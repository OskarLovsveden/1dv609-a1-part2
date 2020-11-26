using Model;
using Model.DAL;
using View;

namespace Controller
{
    public class LyricsController
    {
        private IAppState _appState;
        private IMenu _menu;
        private ISongDAL _songDAL;
        public LyricsController(IAppState appState, IMenu menu, ISongDAL songDAL)
        {
            _appState = appState;
            _menu = menu;
            _songDAL = songDAL;
        }

        public void Run()
        {
            while (_appState.ShouldRun)
            {
                switch (_appState.Current)
                {
                    case MenuOption.ShowMenu:
                        _appState.Current = _menu.ShowMainMenuGetUserSelection();
                        break;
                    case MenuOption.SelectSong:
                        IArtist artist = _menu.GetArtist();
                        ITitle title = _menu.GetSongTitle();
                        ISong song = _songDAL.GetSong(artist, title).Result;
                        break;
                    case MenuOption.Quit:
                        _appState.Exit();
                        break;
                }
            }
        }
    }
}