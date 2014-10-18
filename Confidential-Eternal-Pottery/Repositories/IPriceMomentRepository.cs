using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.Repositories
{
    interface IPriceMomentRepository : IUpdateRepository<PriceMoment>, IFindByIdRepository<PriceMoment>
    {
    }
}