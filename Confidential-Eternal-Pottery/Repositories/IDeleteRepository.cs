using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Repositories
{
    interface IDeleteRepository<T>
    {
        void Delete(T entity);
    }

}
