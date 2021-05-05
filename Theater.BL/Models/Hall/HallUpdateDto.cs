using System;
using System.Collections.Generic;

namespace Theater.BL.Models.Hall
{
    public class HallUpdateDto
    {
        public ICollection<HallSectionCreateUpdateDto> HallSections { get; set; } = new List<HallSectionCreateUpdateDto>();

        public DateTime EffectiveTime { get; set; }
    }
}
