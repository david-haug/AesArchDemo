using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Auth
{
    public interface ITokenService
    {
        string CreateToken();
        bool ValidateToken(string token);
        JwtSecurityToken ReadToken(string token);
    }
}
