using AutoMapper;
using System;
using System.Threading.Tasks;
using Theater.BL.Models.Booking;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.BL.Services
{
    public class BookingService
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public async Task<BookingDto> GetBookingAsync(Guid id)
        {
            var booking = await bookingRepository.GetBookingAsync(id);
            return mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> AddBookingAsync(BookingCreateDto bookingDtoToAdd)
        {
            var bookingToAdd = mapper.Map<Booking>(bookingDtoToAdd);
            var addedBooking = await bookingRepository.AddBookingAsync(bookingToAdd);
            return mapper.Map<BookingDto>(addedBooking);
        }

        public async Task<BookingDto> UpdateBookingAsync(Guid id, BookingUpdateDto bookingDtoPayload)
        {
            var bookingPayload = mapper.Map<Booking>(bookingDtoPayload);
            var updatedBooking = await bookingRepository.UpdateBookingAsync(id, bookingPayload);
            return mapper.Map<BookingDto>(updatedBooking);
        }

        public async Task<BookingDto> DeleteBookingAsync(Guid id)
        {
            var booking = await bookingRepository.DeleteBookingAsync(id);
            return mapper.Map<BookingDto>(booking);
        }
    }
}
