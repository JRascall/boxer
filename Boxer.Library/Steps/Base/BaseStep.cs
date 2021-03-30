using Boxer.Library;
using System;

namespace B.Library.Steps
{
    public abstract class BaseStep : BoxerBase, IStep
    {
        protected readonly Action nextStep;
        public Action NextStep => nextStep;

        public event Action<string> Error;

        protected BaseStep(IServiceProvider services)
            : base(services) { }

        protected BaseStep(IServiceProvider services, Action nextStep = null)
            : this(services)
        {
            this.nextStep = nextStep;
        }

        protected void OnError(string text)
        {
            Error?.Invoke(text);
        }

        public abstract void Run();
    }
}
