using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConfidentialEternalPottery.DomainModel.Repositories;
using ConfidentialEternalPottery.DomainModel;
using System.Data;
using System.Data.Entity;
using ConfidentialEternalPottery.DomainModel.Models;

namespace ConfidentialEternalPottery.Repositories
{
    
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelContext context;
        public GuestRepository(HotelContext hotelContext)
        {
            context = hotelContext;
        }

        Guest IUpdateRepository<Guest>.Update(Guest entity)
        {
            context.Guests.Attach(entity);
            context.Entry<Guest>(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }
        Guest IFindByIdRepository<Guest>.FindById(int id)
        {
            return context.Guests.Find(id);
        }
    }
}