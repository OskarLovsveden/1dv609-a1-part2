using System;
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
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
/*       while(stateThing.shouldRun){
          switch
          case whatTodO.ShowMenu
              determineNextState = view.ShowMenu

          case artistSEarch
              artistGet
              titleGet
              otherStuff
          caase quit
              stateThing.shouldRun = false                    
      }

      systemEXit */