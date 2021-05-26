using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Data.Esn.UserAccounts
{
    public class UserAccountRole
    {
        public int UserAccountRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
    }
}
