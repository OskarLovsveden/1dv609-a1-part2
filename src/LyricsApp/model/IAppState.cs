using View;

namespace Model
{
    public interface IAppState
    {
        bool ShouldRun { get; set; }

        MenuOption Current { get; set; }
    }
}