using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Session;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.BL.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;

        public SessionService(ISessionRepository sessionRepository, IMapper mapper)
        {
            this.sessionRepository = sessionRepository;
            this.mapper = mapper;
        }

        public async Task<SessionDto> GetSessionAsync(Guid id)
        {
            var session = await sessionRepository.GetSessionAsync(id);
            return mapper.Map<SessionDto>(session);
        }

        public async Task<IEnumerable<SessionDto>> GetSessionByHallAsync(Guid hallId, bool includeInactive)
        {
            var sessions = await sessionRepository.GetSessionByHallAsync(hallId, includeInactive);
            return mapper.Map<IEnumerable<SessionDto>>(sessions);
        }

        public async Task<IEnumerable<SessionDto>> GetAllSessionsAsync(bool includeInactive)
        {
            var sessions = await sessionRepository.GetSessionAllAsync(includeInactive);
            return mapper.Map<IEnumerable<SessionDto>>(sessions);
        }

        public async Task<SessionDto> AddSessionAsync(SessionCreateUpdateDto sessionDtoToAdd)
        {
            var sessionToAdd = mapper.Map<Session>(sessionDtoToAdd);
            var addedSession = await sessionRepository.AddSessionAsync(sessionToAdd);
            return mapper.Map<SessionDto>(addedSession);
        }

        public async Task<SessionDto> UpdateSessionAsync(Guid id, SessionCreateUpdateDto sessionDtoPayload)
        {
            var sessionPayload = mapper.Map<Session>(sessionDtoPayload);
            var updatedSession = await sessionRepository.UpdateSessionAsync(id, sessionPayload);
            return mapper.Map<SessionDto>(updatedSession);
        }

        public async Task<SessionDto> DeleteSessionAsync(Guid id)
        {
            var session = await sessionRepository.DeleteSessionAsync(id);
            return mapper.Map<SessionDto>(session);
        }
    }
}
