using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Data.Esn.UserAccounts
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdministrative { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
    }
}
