using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Core.Validators
{
    public class InvalidRule
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Key { get; set; }
        public int Code { get; set; }
    }
}
