namespace B.Library
{
    public interface ILogger
    {
        void Information(string text);
        void Error(string text);
        void Debug(string text);
        void Warning(string text);
    }
}
