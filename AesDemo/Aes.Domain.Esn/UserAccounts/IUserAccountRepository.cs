using System;
using System.Collections.Generic;
using System.Text;
using Aes.Data.Esn.UserAccounts;
using Aes.Domain.Core.Repositories;

namespace Aes.Domain.Esn.UserAccounts
{
    public interface IUserAccountRepository:IDomainRepository<UserAccount>
    {
    }
}
