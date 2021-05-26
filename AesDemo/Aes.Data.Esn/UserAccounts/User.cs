using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Data.Esn.UserAccounts
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CorrespondenceEmail { get; set; }
        public string OfficePhone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool TermsAccepted { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationId { get; set; }
        public bool IsAquilon { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

        //public IEnumerable<UserNotification> Notifications { get; set; }
        //public IEnumerable<UserRole> Roles { get; set; }
    }
}
