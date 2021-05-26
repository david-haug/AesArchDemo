using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Aes.Api.Core.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aes.Api.Core.Filters
{
    public class AuthenticateJwtAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var tokenService = new AesTokenService();

            var request = actionContext.HttpContext.Request;//?.Headers["Basic"]; ;
            var authorization = request.Headers["Authorization"].ToString();
            var token = "";
            if (!string.IsNullOrEmpty(authorization))
            {
                token = authorization.Replace("Bearer ", "");
            }
            else
            {
                actionContext.Result = new UnauthorizedResult();
            }

            var jwt = tokenService.GetValidatedToken(token);
            if (jwt == null)
            {
                actionContext.Result = new UnauthorizedResult();
            }
            else
            {
                //set CurrentUser
                var identity = tokenService.CreateAesIdentity(jwt);
                CurrentUser.UserId = identity.UserId;
                CurrentUser.UserName = identity.UserName;
                CurrentUser.SessionId = identity.SessionId;
                CurrentUser.Roles = identity.Roles;
            }
                



        }
    }
}
