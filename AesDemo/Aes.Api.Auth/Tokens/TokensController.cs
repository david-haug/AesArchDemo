using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aes.Api.Core.Identity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Aes.Api.Auth.Tokens
{
    [Produces("application/json")]
    [Route("auth/Tokens")]
    public class TokensController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] CreateTokenModel model)
        {
            //TODO: real implementation with user lookup

            AesIdentity identity = null;
            if (model.UserName.ToLower() == "jtester" && model.Password == "testm3")
            {
                identity = new AesIdentity("jtester",1677, Guid.NewGuid().ToString("N"), 47,new []{"admin"});
            }
            if (model.UserName.ToLower() == "jtester99" && model.Password == "testm3")
            {
                identity = new AesIdentity("jtester99", 1678, Guid.NewGuid().ToString("N"), 47, new[] { "user" });
            }

            if (identity==null)
                return Unauthorized();

            //create token
            var service = new AesTokenService();
            var token = service.CreateToken(identity.Claims, DateTime.UtcNow.AddMinutes(60));
            return Ok(token);

        }
    }
}