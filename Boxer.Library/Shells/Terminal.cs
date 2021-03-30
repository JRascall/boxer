
using System;

namespace B.Library.Shells
{
    public class Terminal : BaseShell, IShell
    {
        private const string name = "/bin/bash";

        public Terminal(IServiceProvider services)
            : base(services)
        {
            pName = name;
        }
    }
}
