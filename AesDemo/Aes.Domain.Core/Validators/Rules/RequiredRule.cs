using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aes.Domain.Core.Validators.Rules
{
    public class RequiredRule:IRule<string>
    {
        public bool IsInvalid(string obj)
        {
            return string.IsNullOrWhiteSpace(obj);
        }
    }
}
