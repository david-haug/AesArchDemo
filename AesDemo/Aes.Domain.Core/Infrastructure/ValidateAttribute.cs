using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Aes.Domain.Core.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateAttribute:Attribute
    {
        public AbstractValidator<object> Validator { get; set; }


    }
}
