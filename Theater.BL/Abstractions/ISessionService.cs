using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Session;

namespace Theater.BL.Services
{
    public interface ISessionService
    {
        Task<SessionDto> GetSessionAsync(Guid id);

        Task<IEnumerable<SessionDto>> GetSessionByHallAsync(Guid hallId, bool includeInactive);

        Task<IEnumerable<SessionDto>> GetAllSessionsAsync(bool includeInactive);

        Task<SessionDto> AddSessionAsync(SessionCreateUpdateDto sessionDtoToAdd);

        Task<SessionDto> UpdateSessionAsync(Guid id, SessionCreateUpdateDto sessionDtoPayload);

        Task<SessionDto> DeleteSessionAsync(Guid id);
    }
}
