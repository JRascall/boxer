using B.Library.Shells;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace B.Library.Steps
{
    public abstract class ShellStep : BaseStep
    {
        protected readonly IShell shell;
        protected readonly IList<string> commands;

        protected ShellStep
        (
            IServiceProvider services,
            Action nextStep = null
        ) : base(services, nextStep)
        {
            shell = services.GetService<IShell>();
            commands = new List<string>();
        }

        protected abstract void OnCompleted(IShellResult result);
    }
}
