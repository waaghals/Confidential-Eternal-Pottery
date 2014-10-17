using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConfidentialEternalPottery.DomainModel.Repositories;
using ConfidentialEternalPottery.Models;
using System.Data;

namespace ConfidentialEternalPottery.Repositories
{
    
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext context;
        public RoomRepository(HotelContext hotelContext)
        {
            context = hotelContext;
        }

        Room IRoomRepository.findByNumber(int number)
        {
            throw new NotImplementedException();
        }

        Room ICreateRepository<Room>.Create(Room entity)
        {
            return context.Rooms.Add(entity);
        }

        Room IUpdateRepository<Room>.Update(Room entity)
        {
            context.Rooms.Attach(entity);
            context.Entry<Room>(entity).State = EntityState.Modified;

            return entity;
        }

        void IDeleteRepository<Room>.Delete(Room entity)
        {
            context.Rooms.Remove(entity);
        }
    }
}