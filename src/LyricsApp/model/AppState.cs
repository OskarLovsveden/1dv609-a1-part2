using View;

namespace Model
{
    public class AppState : IAppState
    {
        private bool _shouldRun = true;
        private MenuOption _current = MenuOption.ShowMenu;
        public bool ShouldRun { get => _shouldRun; set => _shouldRun = value; }
        public MenuOption Current { get => _current; set => _current = value; }
    }
}