namespace View.utils
{
    public class Prompt : IPrompt
    {
        private IConsoleWrapper _console;
        private string _promptMarker = ">";
        public Prompt(IConsoleWrapper console)
        {
            _console = console;
        }
        public string PromptQuestion(string question)
        {
            _console.WriteLine(question);
            _console.Write(_promptMarker);
            return _console.ReadLine();
        }
    }
}