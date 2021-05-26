using System;
using System.Collections.Generic;
using System.Text;
using Aes.Domain.Core;

namespace Aes.Api.Core.Identity
{
    public class CurrentUser
    {

        public static int UserId { get; set; }
        public static string SessionId { get; set; }
        public static string UserName { get; set; }
        public static int OrgId { get; set; }
        public static string[] Roles { get; set; }
        public static IUser ToUser()
        {
            return new User
            {
                UserId = UserId,
                Roles = Roles
            };
        }
    }
}
