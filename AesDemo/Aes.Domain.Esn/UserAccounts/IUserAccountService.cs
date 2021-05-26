using System;
using System.Collections.Generic;
using System.Text;
using Aes.Data.Esn.UserAccounts;
using Aes.Data.Esn.UserAccounts.Commands;

namespace Aes.Domain.Esn.UserAccounts
{
    public interface IUserAccountService
    {
        IEnumerable<UserAccount> GetUserAccounts();
        UserAccount GetUserAccount(int userId);
        UserAccount CreateUserAccount(CreateUserAccountCommand command);
        UserAccount UpdateUserAccount(UpdateUserAccountCommand command);
        void DeleteUserAccount(int userId);
    }
}
