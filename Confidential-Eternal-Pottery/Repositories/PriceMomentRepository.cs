using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConfidentialEternalPottery.DomainModel.Repositories;
using ConfidentialEternalPottery.Models;
using System.Data;
using System.Data.Entity;

namespace ConfidentialEternalPottery.Repositories
{
    public class PriceMomentRepository : IPriceMomentRepository
    {
        private readonly HotelContext context;
        public PriceMomentRepository(HotelContext hotelContext)
        {
            context = hotelContext;
        }

        PriceMoment IFindByIdRepository<PriceMoment>.FindById(int priceMomentId) 
        {
            List<Room> rooms = context.Rooms.ToList<Room>();
            foreach (var room in rooms)
            {
                foreach (var price in room.Prices)
                {
                    if (price.PriceMomentId == priceMomentId)
                    {
                        return price;
                    }
                }
            }
            return null;
        }

        PriceMoment IUpdateRepository<PriceMoment>.Update(PriceMoment entity)
        {
            context.Entry<PriceMoment>(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

    }
}