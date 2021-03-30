using Boxer.Packers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Boxer.Commands
{
    class Pack : BaseCommand, ICommand
    {
        private readonly IPacker _packer;

        public string Name => "pack";
        public Pack(IServiceProvider services)
            : base(services)
        {
            _packer = services.GetService<IPacker>();
        }

        public Task Run(params string[] args)
        {
            _packer.Pack(args[0]);
            return Task.CompletedTask;
        }
    }
}
