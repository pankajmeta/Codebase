using FactorialService.Models;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorialService
{
    public class Module : NancyModule
    {
        private ILogger<Module> _logger;

        public Module(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Module>();

            Get("/factorial/{number:int}", p => GetFactorial(new FactorialRequest { Number = p.number }));
        }

        FactorialResponse GetFactorial(FactorialRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                _logger.LogInformation($"Failed to generate factorial for {request.Number}");
                return new FactorialResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new FactorialResponse { Success = true, Factorial = Factorial(request.Number) };
            _logger.LogInformation($"Generated Factorial for {request.Number}: {result.Factorial}");

            return result;
        }

        int Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    }
}
