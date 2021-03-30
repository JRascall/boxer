using B.Library;
using B.Library.Shells;
using Boxer.Library;
using Boxer.Packers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.InteropServices;

namespace Boxer
{
    class Program
    {
        private static IServiceProvider _services;
        private static bool _isWindows;

        public static ILogger logger =>
            _services.GetService<ILogger>();
        public static ICommandProcessor commandProcessor =>
            _services.GetService<ICommandProcessor>();


        static void Main(string[] args)
        {
            _isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            var builder = CreateHostBuilder(args);
            builder.ConfigureServices(ConfigureServices);
            var host = builder.Build();
            _services = host.Services;

            while (EnterCommand() != string.Empty) ;
        }



        private static string EnterCommand()
        {
            Console.WriteLine("Enter command:");
            var line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) return line;


            try
            {
                commandProcessor.Process(line).Wait();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

            return line;
        }


        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args);
        }

        static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<ICommandProcessor, CommandProcessor>();
            services.AddSingleton<INodeRuntime, NodePortableRuntime>();

            services.AddTransient<IShell>(x =>
            {
                var logger = x.GetService<ILogger>();
                if (_isWindows) return new CommandPrompt(x);
                else return new Terminal(x);
            });

            services.AddTransient<IPacker, TypescriptPacker>();
        }
    }
}
