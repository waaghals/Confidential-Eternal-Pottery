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
    
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext context;
        public RoomRepository(HotelContext hotelContext)
        {
            context = hotelContext;
        }

        List<Room> IFindAllRepository<Room>.FindAll(Room entity)
        {
            return context.Rooms.ToList<Room>();
        }

        Room IRoomRepository.findByNumber(int number)
        {
            return context.Rooms.Where(room => room.Number == number).FirstOrDefault();
        }

        Room ICreateRepository<Room>.Create(Room entity)
        {
            var room = context.Rooms.Add(entity);
            context.SaveChanges();
            return room;
        }

        Room IUpdateRepository<Room>.Update(Room entity)
        {
            context.Rooms.Attach(entity);
            context.Entry<Room>(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        void IDeleteRepository<Room>.Delete(Room entity)
        {
            context.Rooms.Remove(entity);
        }

        public void DeleteById(int roomId)
        {
            var entity = context.Rooms.Where(room => room.RoomId == roomId).FirstOrDefault();
            if (entity != null)
            {
                context.Rooms.Remove(entity);
                context.SaveChanges();
            }
        }

        public Room FindById(int Id)
        {
            return context.Rooms.Find(Id);
        }
    }
}