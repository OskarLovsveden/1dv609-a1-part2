using System.Net.Http;
using Controller;
using Model;
using Model.DAL;
using View;
using View.utils;

namespace LyricsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IAppState appState = new AppState();
            IConsoleWrapper console = new ConsoleWrapper();
            IPrompt prompt = new Prompt(console);
            IMenu menu = new Menu(prompt);
            HttpClient httpClient = new HttpClient();
            IFetch fetch = new Fetch(httpClient);
            ITrackDAL trackDAL = new TrackDAL(fetch);
            ISongDAL songDAL = new SongDAL(fetch, trackDAL);

            LyricsController controller = new LyricsController(appState, menu, songDAL);
            controller.Run();
        }
    }
}
