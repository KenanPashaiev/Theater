using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Models;

namespace Theater.DAL.Abstractions
{
    public interface ISessionRepository
    {
        Task<Session> GetSessionAsync(Guid id);

        Task<IEnumerable<Session>> GetSessionByHallAsync(Guid hallId, bool includeInactive);

        Task<IEnumerable<Session>> GetSessionAllAsync(bool includeInactive);

        Task<Session> AddSessionAsync(Session entity);

        Task<Session> UpdateSessionAsync(Guid id, Session entity);

        Task<Session> DeleteSessionAsync(Guid id);
    }
}
