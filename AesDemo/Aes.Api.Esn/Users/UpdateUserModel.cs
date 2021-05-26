using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aes.Data.Esn.UserAccounts.Commands;

namespace Aes.Api.Esn.Users
{
    public class UpdateUserModel
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

        public static UpdateUserAccountCommand Map(UpdateUserModel model)
        {
            return new UpdateUserAccountCommand
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CorrespondenceEmail = model.CorrespondenceEmail,
                OfficePhone = model.OfficePhone,
                CellPhone = model.CellPhone,
                Fax = model.Fax,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                Country = model.Country,
                State = model.State,
                PostalCode = model.PostalCode
            };
        }
    }
}
