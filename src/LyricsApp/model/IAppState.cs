namespace Model
{
    public interface IAppState
    {
        bool ShouldRun { get; }

        MenuOption Current { get; set; }

        void Exit();
    }
}