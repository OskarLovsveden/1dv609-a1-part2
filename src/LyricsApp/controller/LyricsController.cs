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
            /*     while(stateThing.shouldRun){
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
            throw new NotImplementedException();
        }
    }
}