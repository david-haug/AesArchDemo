using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Data.Esn.UserAccounts.Commands
{
    public class CreateUserAccountCommand
    {
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
        public int CreatedBy { get; set; }
    }
}
