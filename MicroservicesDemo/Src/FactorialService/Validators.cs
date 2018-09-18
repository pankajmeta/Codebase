using FactorialService.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactorialService
{
    public class FactorialRequestValidator : AbstractValidator<FactorialRequest>
    {
        public FactorialRequestValidator()
        {
            RuleFor(request => request.Number).InclusiveBetween(1, 12);
        }
    }
}
