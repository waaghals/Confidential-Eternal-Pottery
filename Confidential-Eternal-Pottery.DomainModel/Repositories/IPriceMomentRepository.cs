using ConfidentialEternalPottery.DomainModel;
using ConfidentialEternalPottery.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConfidentialEternalPottery.DomainModel.Repositories
{
    public interface IPriceMomentRepository : IUpdateRepository<PriceMoment>, IFindByIdRepository<PriceMoment>
    {
    }
}