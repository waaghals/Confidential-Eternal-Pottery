using ConfidentialEternalPottery.DomainModel.Models;
using ConfidentialEternalPottery.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfidentialEternalPottery.DomainModel.Repositories
{
    public interface IBookingRepository: ICreateRepository<Booking>, IUpdateRepository<Booking>, IFindAllRepository<Booking>
    {
        
    }
}
