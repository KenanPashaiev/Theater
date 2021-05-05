using System;
using Theater.Models.Enums;

namespace Theater.BL.Models.Session
{
    public class SessionCreateUpdateDto
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public SessionType SessionType { get; set; }

        public DateTime BookingOpenDate { get; set; }

        public DateTime BookingCloseDate { get; set; }

        public Guid HallId { get; set; }
    }
}
