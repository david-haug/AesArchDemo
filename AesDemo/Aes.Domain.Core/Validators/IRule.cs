using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Core.Validators
{
    public interface IRule<in T>
    {
        bool IsInvalid(T obj);
    }
}
