using System;
using System.Collections.Generic;
using Theater.Models.Enums;

namespace Theater.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public SessionType SessionType { get; set; }

        public DateTime BookingOpenDate { get; set; }

        public DateTime BookingCloseDate { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Guid HallId { get; set; }
    }
}
