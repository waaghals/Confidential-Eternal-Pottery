using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    interface ICrudRepository<T>
    {
        T Create(T entity);
        T Update(T entity);
        T Get();
        List<T> GetAll();
        void Delete(T entity);
    }
}
