namespace Model
{
    public class AppState : IAppState
    {
        private bool _shouldRun = true;
        private MenuOption _current = MenuOption.ShowMenu;
        public bool ShouldRun { get => _shouldRun; }
        public MenuOption Current { get => _current; set => throw new System.NotImplementedException(); }

        public void Exit()
        {
            _shouldRun = false;
        }
    }
}