using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aes.Api.Core.Identity
{
    public interface ITokenService
    {
        string CreateToken(IEnumerable<Claim> claims, DateTime tokenExpiration);
        JwtSecurityToken GetValidatedToken(string token);
        JwtSecurityToken ReadToken(string token);
    }
}
