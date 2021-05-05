using System;

namespace Theater.BL.Models.Booking
{
    public class BookingUpdateDto
    {
        public DateTime BookedDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Row { get; set; }

        public int Seat { get; set; }

        public Guid HallSectionId { get; set; }

        public bool IsActive { get; set; }
    }
}
