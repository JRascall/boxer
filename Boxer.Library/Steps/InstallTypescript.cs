using B.Library.Shells;
using Boxer.Library.Steps.Base;
using System;

namespace B.Library.Steps
{
    public class InstallTypescript : NodeStep
    {
        public InstallTypescript(IServiceProvider services, Action nextStep = null)
            : base(services, nextStep) { }

        public override void Run()
        {
            logger.Debug("Installing typescript...");
            commands.Add("npm install -g typescript");

            base.Run();
        }

        protected override void OnCompleted(IShellResult result)
        {
            logger.Debug("Installed typescript");
            NextStep?.Invoke();
        }
    }
}
