using System;

namespace Theater.Models
{
    public class HallSection
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int RowCount { get; set; }

        public int SeatCount { get; set; }

        public int Order { get; set; }

        public Hall Hall { get; set; }
    }
}
