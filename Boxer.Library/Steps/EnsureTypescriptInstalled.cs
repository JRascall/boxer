using B.Library.Exceptions;
using B.Library.Shells;
using Boxer.Library.Steps.Base;
using System;

namespace B.Library.Steps
{
    public class EnsureTypescriptInstalled : NodeStep
    {
        public EnsureTypescriptInstalled(IServiceProvider services, Action nextStep = null)
            : base(services, nextStep) { }

        public override void Run()
        {
            logger.Debug("Checking if typescript is installed...");

            commands.Add("tsc");

            base.Run();

        }

        protected override void OnCompleted(IShellResult result)
        {
            Helper.ThrowIf<TypescriptNotInstalledException>(result.Error);

            logger.Debug("Typescript is installed");

            NextStep?.Invoke();
        }
    }
}
