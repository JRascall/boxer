using System;

namespace B.Library.Shells
{
    public class CommandPrompt : BaseShell, IShell
    {
        private const string name = "cmd.exe";

        public CommandPrompt(IServiceProvider services)
            : base(services)
        {
            pName = name;
        }
    }

}
