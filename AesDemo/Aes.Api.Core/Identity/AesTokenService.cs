using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Aes.Api.Core.Identity
{
    public class AesTokenService:ITokenService
    {
        private const string Secret = "Jn@LqteNa*%bt%dhn6xm@Z=Fhhqcb8z&9tFrf!8xDe6$$Cq97rsP%Q_Gz#n*hWKn_AXwerQ*y=A-Bx6sYh9dU=pswyyf%Z+XcrARQ7fxUneyVT2@t!f5b+GR#Q&HAz$u";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(Secret));

        public string CreateToken(IEnumerable<Claim> claims, DateTime tokenExpiration)
        {
            var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: tokenExpiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public JwtSecurityToken GetValidatedToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var param = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    IssuerSigningKey = _signingKey,
                    ValidateLifetime = true
                };
                handler.ValidateToken(token, param, out var validatedToken);
                return (JwtSecurityToken) validatedToken;
            }
            catch (SecurityTokenException)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JwtSecurityToken ReadToken(string token)
        {
            throw new NotImplementedException();
        }

        public AesIdentity CreateAesIdentity(JwtSecurityToken token)
        {
            var userId = token.Claims.FirstOrDefault(c => c.Type == AesIdentity.Keys.Sub)?.Value;
            var userName = token.Claims.FirstOrDefault(c => c.Type == AesIdentity.Keys.Actor)?.Value;
            var sessionId = token.Claims.FirstOrDefault(c => c.Type == AesIdentity.Keys.Jti)?.Value;
            var orgId = token.Claims.FirstOrDefault(c => c.Type == AesIdentity.Keys.Org)?.Value;
            var roles = token.Claims.FirstOrDefault(c => c.Type == AesIdentity.Keys.Roles)?.Value;

            return new AesIdentity(userName,Convert.ToInt32(userId),sessionId, Convert.ToInt32(orgId),roles.Split(','));
        }
    }
}
