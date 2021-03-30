using B.Library.Exceptions;
using B.Library.Shells;
using Boxer.Library.Steps.Base;
using System;

namespace B.Library.Steps.Base
{
    public class EnsureNPMInstalled : NodeStep
    {
        public EnsureNPMInstalled(IServiceProvider services, Action nextStep = null)
            : base(services, nextStep)
        { }

        public override void Run()
        {
            logger.Debug("Checking if NPM is installed...");

            commands.Add("npm");

            base.Run();
        }

        protected override void OnCompleted(IShellResult result)
        {
            Helper.ThrowIf<NPMNotInstalledException>(result.Error);

            logger.Debug("NPM is installed");

            NextStep?.Invoke();
        }
    }
}
