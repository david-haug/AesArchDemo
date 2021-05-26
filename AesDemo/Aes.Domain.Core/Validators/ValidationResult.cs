using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aes.Domain.Core.Validators
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            InvalidRules = new List<InvalidRule>();
        }

        public List<InvalidRule> InvalidRules { get; set; }
        public bool Invalid => InvalidRules.Any();
    }
}
