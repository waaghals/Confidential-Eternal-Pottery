using ConfidentialEternalPottery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfidentialEternalPottery.Models;

namespace ConfidentialEternalPottery.Repositories
{
    interface IBookingRepository: ICreateRepository<Booking>, IUpdateRepository<Booking>
    {
        
    }
}
