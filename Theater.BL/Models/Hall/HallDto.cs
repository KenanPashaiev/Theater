using System;
using System.Collections.Generic;

namespace Theater.BL.Models.Hall
{
    public class HallDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<HallSectionDto> HallSections { get; set; } = new List<HallSectionDto>();

        public DateTime EffectiveTime { get; set; }
    }
}
