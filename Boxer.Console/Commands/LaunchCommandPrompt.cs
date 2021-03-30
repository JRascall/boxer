using B.Library;
using B.Library.Shells;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Boxer
{
    class LaunchCommandPrompt : BaseCommand, ICommand
    {
        private IShell shell => services.GetService<IShell>();

        public string Name => "cmd";

        public LaunchCommandPrompt(IServiceProvider services)
            : base(services) { }

        public Task Run(params string[] args)
        {
            shell.Run("test", OnCompleted);
            return Task.CompletedTask;
        }

        private void OnCompleted(IShellResult result)
        {
            logger.Debug(result.Output);
        }
    }
}
