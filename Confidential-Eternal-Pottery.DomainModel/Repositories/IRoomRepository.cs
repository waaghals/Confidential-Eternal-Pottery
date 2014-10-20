using ConfidentialEternalPottery.DomainModel.Models;
using ConfidentialEternalPottery.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfidentialEternalPottery.DomainModel.Repositories
{
    public interface IRoomRepository : ICreateRepository<Room>, IUpdateRepository<Room>, IDeleteRepository<Room>, IFindAllRepository<Room>, IFindByIdRepository<Room>
    {
        Room findByNumber(int number);
        void DeleteById(int roomId);
        void RemovePriceMomentById(int priceMomentId, int roomId);
    }
}
