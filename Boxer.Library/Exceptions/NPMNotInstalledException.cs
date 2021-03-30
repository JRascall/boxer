using System;

namespace B.Library.Exceptions
{
    class NPMNotInstalledException : Exception
    {
        public override string Message => "NPM is not installed.";
    }
}
