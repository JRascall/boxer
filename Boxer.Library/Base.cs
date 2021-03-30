using B.Library;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Boxer.Library
{
    public abstract class BoxerBase
    {
        private ILogger _logger;

        protected ILogger logger => _logger;

        protected BoxerBase(IServiceProvider services)
        {
            _logger = services.GetService<ILogger>();
        }
    }
}
