using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Core.Validators
{
    public class AesValidator<T> : IValidator<T>
    {
        protected T ObjectToValidate;
        protected List<InvalidRule> InvalidRules;
        protected List<Action> Rules;

        public ValidationResult Validate(T obj)
        {
            return Validate(obj, Rules);
        }

        public ValidationResult Validate(T obj, List<Action> rules)
        {
            var result = new ValidationResult();
            InvalidRules = new List<InvalidRule>();
            ObjectToValidate = obj;

            foreach (var rule in rules)
                rule.Invoke();

            foreach (var invalid in InvalidRules)
                result.InvalidRules.Add(invalid);

            return result;
        }
    }
}

