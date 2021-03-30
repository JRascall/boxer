namespace B.Library.Shells
{
    public interface IShellResult
    {
        bool Error { get; }
        string Output { get; }
    }
}
