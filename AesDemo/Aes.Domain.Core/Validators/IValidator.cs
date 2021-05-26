using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Core.Validators
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T obj, List<Action> rules);
    }
}
