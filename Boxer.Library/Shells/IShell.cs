using B.Library.Shells;
using System;

namespace B.Library
{
    public interface IShell
    {
        void Run(string cmd, Action<IShellResult> func);
    }
}
