using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Aes.Api.Core.Identity
{
    public class AesIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string SessionId { get; set; }
        public int OrgId { get; set; }
        public string[] Roles { get; set; }
        public AesIdentity(string userName, int userId, string sessionId, int orgId, string[] roles) : base(userName)
        {
            UserName = userName;
            UserId = userId;
            SessionId = sessionId;
            OrgId = orgId;
            Roles = roles;

            AddClaim(new Claim(Keys.Sub,userId.ToString()));
            AddClaim(new Claim(Keys.Jti, sessionId));
            AddClaim(new Claim(Keys.Actor, userName));
            AddClaim(new Claim(Keys.Org, orgId.ToString()));
            AddClaim(new Claim(Keys.Roles, String.Join(",", roles)));
        }

        public class Keys
        {
            public const string Sub = "sub";
            public const string Jti = "jti";
            public const string Actor = "actort";
            public const string Org = "org";
            public const string Roles = "roles";
        }
    }
}
