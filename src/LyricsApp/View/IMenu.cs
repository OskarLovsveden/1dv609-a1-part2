using Model;

namespace View
{
    public interface IMenu
    {
        MenuOption ShowMainMenuGetUserSelection();

        IArtist GetArtist();

        ITitle GetSongTitle();
    }
}