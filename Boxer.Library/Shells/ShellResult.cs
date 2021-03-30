namespace B.Library.Shells
{
    public class ShellResult : IShellResult
    {
        public bool Error { get; set; }
        public string Output { get; set; }

        private ShellResult() { }

        public static IShellResult Create(bool error, string message)
        {
            return new ShellResult
            {
                Error = error,
                Output = message
            };
        }
    }
}
