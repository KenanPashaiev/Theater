using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Hall;

namespace Theater.BL.Services
{
    public interface IHallService
    {
        Task<HallDto> GetHallAsync(Guid id);

        Task<HallDto> GetHallByNameAsync(string name);

        Task<IEnumerable<HallDto>> GetAllHallsAsync(bool includeInactive);

        Task<HallDto> AddHallAsync(HallCreateDto hallDtoToAdd);

        Task<HallDto> UpdateHallAsync(string name, HallUpdateDto hallDtoPayload);

        Task<HallDto> DeleteHallAsync(string name);
    }
}
