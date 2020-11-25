namespace Model
{
    public interface ILyric
    {
        string LyricText { get; }

        int CountAllWords();

        int WordFrequency(string toBeCounted);

    }
}