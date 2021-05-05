namespace Theater.BL.Models.Hall
{
    public class HallSectionCreateUpdateDto
    {
        public string Name { get; set; }

        public int RowCount { get; set; }

        public int SeatCount { get; set; }

        public int Order { get; set; }
    }
}
