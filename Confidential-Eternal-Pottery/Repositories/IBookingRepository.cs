using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfidentialEternalPottery.Repositories
{
    interface IBookingRepository: ICreateRepository<Booking>, IUpdateRepository<Booking>
    {
        
    }
}
