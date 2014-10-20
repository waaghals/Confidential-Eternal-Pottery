using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfidentialEternalPottery.DomainModel.Repositories
{
    public interface ICrudRepository<T>
    {
        List<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        T FindById(int id);
    }
}
