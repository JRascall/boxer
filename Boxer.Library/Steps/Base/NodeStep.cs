using B.Library;
using B.Library.Shells;
using B.Library.Steps;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Boxer.Library.Steps.Base
{
    public class NodeStep : ShellStep
    {
        protected readonly INodeRuntime nodeRuntime;
        protected virtual string command => string.Join(" && ", commands);

        public NodeStep(IServiceProvider services,
            Action nextStep = null)
            : base(services, nextStep)
        {

            nodeRuntime = services.GetService<INodeRuntime>();
            Helper.ThrowIf<ArgumentNullException>(nodeRuntime == null, "Missing node runtime info");

            commands.Add($"cd \"{nodeRuntime.Path}\"");
        }

        public override void Run()
        {
            shell.Run(command, OnCompleted);
        }

        protected override void OnCompleted(IShellResult result)
        {
            Helper.ThrowIf(result.Error, "Failed to install typescript");

            NextStep?.Invoke();
        }
    }
}
