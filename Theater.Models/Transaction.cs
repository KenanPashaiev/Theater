using System;
using System.Collections.Generic;
using Theater.Models.Enums;

namespace Theater.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Card { get; set; }

        public TransactionType TransactionType { get; set; }

        public Guid UserId { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
