namespace TouchSide
{
    public interface IScrabble
    {
        string word { get; set; }
        int Score();
        int Score(string word);
    }
}