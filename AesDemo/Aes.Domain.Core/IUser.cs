using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Core
{
    public interface IUser
    {
        int UserId { get; set; }
        string[] Roles { get; set; }
        bool HasRole(string role);
    }
}
