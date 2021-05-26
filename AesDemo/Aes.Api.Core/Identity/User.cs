using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aes.Domain.Core;

namespace Aes.Api.Core.Identity
{
    public class User:IUser
    {
        public int UserId { get; set; }
        public string[] Roles { get; set; }
        public bool HasRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
