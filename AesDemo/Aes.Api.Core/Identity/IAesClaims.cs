using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Api.Core.Identity
{
    public interface IAesClaims
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string SessionId { get; set; }
        string[] Roles { get; set; }
    }
}
