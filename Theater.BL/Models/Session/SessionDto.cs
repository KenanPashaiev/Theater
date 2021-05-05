using System;
using System.Collections.Generic;
using Theater.BL.Models.Booking;
using Theater.Models.Enums;

namespace Theater.BL.Models.Session
{
    public class SessionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public SessionType SessionType { get; set; }

        public DateTime BookingOpenDate { get; set; }

        public DateTime BookingCloseDate { get; set; }

        public ICollection<BookingDto> Bookings { get; set; }

        public Guid HallId { get; set; }
    }
}
