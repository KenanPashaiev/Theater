using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Booking;

namespace Theater.BL.Services
{
    public interface IBookingService
    {
        Task<BookingDto> GetBookingAsync(Guid id);

        Task<BookingDto> GetBookingByNameAsync(string name);

        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();

        Task<BookingDto> AddBookingAsync(BookingCreateDto bookingDtoToAdd);

        Task<BookingDto> UpdateBookingAsync(Guid id, BookingUpdateDto bookingDtoPayload);

        Task<BookingDto> DeleteBookingAsync(Guid id);
    }
}
