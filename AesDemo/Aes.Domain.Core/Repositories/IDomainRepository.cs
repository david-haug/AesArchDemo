using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Domain.Core.Repositories
{
    public interface IDomainRepository<T>
    {
        T Get(int id);
        List<T> GetAll();
        //List<T> Search(ISearchFilter filter = null);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);

    }
}
