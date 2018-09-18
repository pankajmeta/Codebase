using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorialService
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        readonly IServiceProvider _serviceProvider;

        public Bootstrapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<ILoggerFactory, LoggerFactory>();
        }
    }
}
