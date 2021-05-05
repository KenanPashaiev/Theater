using System;
using System.Collections.Generic;

namespace Theater.BL.Models.Hall
{
    public class HallCreateDto
    {
        public string Name { get; set; }

        public ICollection<HallSectionCreateUpdateDto> HallSections { get; set; } = new List<HallSectionCreateUpdateDto>();

        public DateTime EffectiveTime { get; set; }
    }
}
