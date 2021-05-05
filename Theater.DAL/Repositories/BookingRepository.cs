using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationContext applicationContext;

        public BookingRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Booking> GetBookingAsync(Guid id)
        {
            return await applicationContext.Bookings.
                SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Booking> AddBookingAsync(Booking entity)
        {
            var booking = await applicationContext.Bookings.AddAsync(entity);
            applicationContext.SaveChanges();
            return await GetBookingAsync(booking.Entity.Id);
        }

        public async Task<Booking> UpdateBookingAsync(Guid id, Booking entity)
        {
            var booking = await GetBookingAsync(id);
            booking.FirstName = entity.FirstName;
            booking.LastName = entity.LastName;
            booking.Row = entity.Row;
            booking.Seat = entity.Seat;
            booking.HallSectionId = entity.HallSectionId;
            booking.UpdatedDate = DateTime.UtcNow;
            booking.IsActive = entity.IsActive;
            applicationContext.SaveChanges();
            return booking;
        }

        public async Task<Booking> DeleteBookingAsync(Guid id)
        {
            var booking = await GetBookingAsync(id);
            booking.IsActive = false;
            applicationContext.SaveChanges();
            return booking;
        }
    }
}
