using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Aes.Domain.Auth
{
    class AesClaims
    {
        public AesClaims(int userId, string sessionId, string userName)
        {
            Claims = new List<Claim>
            {
                new Claim(Keys.Sub, userId.ToString()),
                new Claim(Keys.Jti, sessionId),
                new Claim(Keys.Actor, userName)
            };
        }

        public IEnumerable<Claim> Claims { get; }

        public class Keys
        {
            public const string Sub = "sub";
            public const string Jti = "jti";
            public const string Actor = "actort";
        }
    }
}
