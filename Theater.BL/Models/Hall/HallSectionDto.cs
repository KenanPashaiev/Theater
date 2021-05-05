using System;

namespace Theater.BL.Models.Hall
{
    public class HallSectionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int RowCount { get; set; }

        public int SeatCount { get; set; }

        public int Order { get; set; }
    }
}
