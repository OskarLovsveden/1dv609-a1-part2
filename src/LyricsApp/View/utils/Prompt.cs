namespace View.utils
{
    public class Prompt : IPrompt
    {
        private IConsoleWrapper _console;
        public Prompt(IConsoleWrapper console)
        {
            _console = console;
        }
        public string PromptQuestion(string question)
        {
            throw new System.NotImplementedException();
        }
    }
}