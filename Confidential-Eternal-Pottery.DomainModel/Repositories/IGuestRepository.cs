using ConfidentialEternalPottery.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfidentialEternalPottery.DomainModel.Repositories
{
    public interface IGuestRepository : IFindByIdRepository<Guest>, IUpdateRepository<Guest>
    {
    }
}
