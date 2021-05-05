using System;
using System.Collections.Generic;

namespace Theater.Models
{
    public class Hall
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<HallSection> HallSections { get; set; } = new List<HallSection>();

        public DateTime EffectiveTime { get; set; }
    }
}
