using B.Library;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Boxer
{
    abstract class BaseCommand
    {
        protected readonly IServiceProvider services;
        protected readonly ILogger logger;

        protected BaseCommand(IServiceProvider services)
        {
            this.services = services;
            logger = services.GetService<ILogger>();
        }
    }
}
