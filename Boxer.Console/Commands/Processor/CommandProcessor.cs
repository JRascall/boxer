using B.Library;
using Boxer.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxer
{
    class CommandProcessor : ICommandProcessor
    {
        private readonly IServiceProvider _services;
        private readonly ILogger _logger;
        private readonly IDictionary<string, ICommand> _commands
            = new Dictionary<string, ICommand>();

        public CommandProcessor(IServiceProvider services)
        {
            _services = services;
            _logger = services.GetService<ILogger>();

            RegisterCommand<LaunchCommandPrompt>();
            RegisterCommand<Pack>();
        }

        private void RegisterCommand<T>()
            where T : ICommand
        {
            try
            {
                var instance = (T)Activator.CreateInstance(typeof(T), _services);
                _commands.Add(instance.Name.ToLower(), instance);
            }
            catch (Exception ex)
            {
                _logger.Error($"Cannot register command - {typeof(T).Name}");
                _logger.Error(ex.InnerException.Message);
            }
        }

        public async Task Process(string @string)
        {
            Helper.ThrowIf<ArgumentNullException>(
                string.IsNullOrEmpty(@string),
                "@string is null"
            );


            var split = @string.Split(' ');
            var cmd = split[0].ToLower();
            var args = split.Skip(1).ToList();

            var hasCommand = _commands.TryGetValue(cmd, out var command);
            if (hasCommand)
            {
                await command.Run(args.ToArray());
            }
        }

        public ICollection<string> RegisteredCommands()
        {
            throw new NotImplementedException();
        }
    }
}
