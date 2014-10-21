using ConfidentialEternalPottery.DomainModel;
using ConfidentialEternalPottery.DomainModel.Repositories;
using ConfidentialEternalPottery.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ConfidentialEternalPottery.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelContext context;
        public BookingRepository(HotelContext hotelContext)
        {
            context = hotelContext;
        }

        public Booking Create(Booking entity)
        {
            return context.Bookings.Add(entity);
        }

        public Booking Update(Booking entity)
        {
            context.Bookings.Attach(entity);
            context.Entry<Booking>(entity).State = EntityState.Modified;

            return entity;
        }

        public List<Booking> FindAll()
        {
            return context.Bookings.ToList<Booking>();;
        }
    }
}