using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Aes.Data.Core;

namespace Aes.Domain.Core.Exceptions
{
    public class ValidationException:Exception
    {
        public ValidationException(string message, IEnumerable<ValidationError> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }

        public IEnumerable<ValidationError> ValidationErrors { get; }
    }
}
