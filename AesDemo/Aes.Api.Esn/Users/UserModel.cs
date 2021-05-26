using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aes.Data.Esn.UserAccounts;

namespace Aes.Api.Esn.Users
{
    public class UserModel
    {
        public int Id { get; set; }
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
        public DateTime LastModified { get; set; }

        public static UserModel Map(UserAccount user)
        {
            return new UserModel
            {
                Id = user.UserAccountId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                CorrespondenceEmail = user.CorrespondenceEmail,
                OfficePhone = user.OfficePhone,
                CellPhone = user.CellPhone,
                Fax = user.Fax,
                Address1 = user.Address1,
                Address2 = user.Address2,
                City = user.City,
                Country = user.Country,
                State = user.State,
                PostalCode = user.PostalCode,
                LastModified = user.Modified
            };
        }


    }
}
