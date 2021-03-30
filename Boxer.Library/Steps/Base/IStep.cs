using System;

namespace B.Library.Steps
{
    public interface IStep
    {
        Action NextStep { get; }

        event Action<string> Error;
        void Run();
    }
}
