using System;

namespace B.Library.Exceptions
{
    class TypescriptNotInstalledException : Exception
    {
        public override string Message => "Typescript is not installed.";
    }
}
