using System;
using System.Collections.Generic;
using Theater.BL.Models.Booking;
using Theater.Models.Enums;

namespace Theater.BL.Models.Transaction
{
    public class TransactionCreateDto
    {
        public decimal Price { get; set; }

        public string Card { get; set; }

        public TransactionType TransactionType { get; set; }

        public Guid UserId { get; set; }

        public ICollection<BookingCreateDto> Bookings { get; set; }
    }
}
