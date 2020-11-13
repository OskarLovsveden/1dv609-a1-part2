namespace View.utils
{
    public interface IConsoleWrapper
    {
         void Write(string input);
         void WriteLine(string input);
         string ReadLine();
    }
}