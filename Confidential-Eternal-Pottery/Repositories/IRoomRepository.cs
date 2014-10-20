using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfidentialEternalPottery.Repositories
{
    interface IRoomRepository: ICreateRepository<Room>, IUpdateRepository<Room>, IDeleteRepository<Room>
    {
        Room FindByNumber(int number);
        Room FindById(int id);
    }
}
