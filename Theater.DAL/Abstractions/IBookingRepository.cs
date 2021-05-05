using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Models;

namespace Theater.DAL.Abstractions
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingAsync(Guid id);

        Task<Booking> AddBookingAsync(Booking entity);

        Task<Booking> UpdateBookingAsync(Guid id, Booking entity);

        Task<Booking> DeleteBookingAsync(Guid id);
    }
}
