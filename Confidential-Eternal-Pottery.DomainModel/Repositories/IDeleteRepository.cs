using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.DomainModel.Repositories
{
    public interface IDeleteRepository<T>
    {
        void Delete(T entity);
    }

}
