using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aes.Api.Auth.Tokens
{
    public class CreateTokenModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
