using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfidentialEternalPottery.Repositories
{
    interface IFindByIdRepository<T>
    {
        T FindById(int Id);
    }

}
