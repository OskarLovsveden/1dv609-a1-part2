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
            _console.WriteLine(question);
            _console.Write(">");
            return _console.ReadLine();
        }
    }
}