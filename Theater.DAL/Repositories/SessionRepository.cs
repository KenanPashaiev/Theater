using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.DAL.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationContext applicationContext;

        public SessionRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Session> GetSessionAsync(Guid id)
        {
            return await applicationContext.Sessions.
                SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Session>> GetSessionByHallAsync(Guid hallId, bool includeInactive)
        {
            var now = DateTime.UtcNow;
            var halls = await applicationContext.Sessions
                .Include(h => h.Bookings)
                .Where(h => ((h.BookingOpenDate <= now &&
                        now <= h.BookingCloseDate) || includeInactive) && h.HallId == hallId).ToListAsync();
            
            return halls;
        }

        public async Task<IEnumerable<Session>> GetSessionAllAsync(bool includeInactive)
        {
            var now = DateTime.UtcNow;
            var halls = await applicationContext.Sessions
                .Include(h => h.Bookings)
                .Where(h => (h.BookingOpenDate <= now && 
                        now <= h.BookingCloseDate) || includeInactive).ToListAsync();

            return halls;
        }

        public async Task<Session> AddSessionAsync(Session entity)
        {
            var session = await applicationContext.Sessions.AddAsync(entity);
            applicationContext.SaveChanges();
            return await GetSessionAsync(session.Entity.Id);
        }

        public async Task<Session> UpdateSessionAsync(Guid id, Session entity)
        {
            var session = await applicationContext.Sessions.SingleOrDefaultAsync(s => s.Id == id);
            session.Name = entity.Name;
            session.StartTime = entity.StartTime;
            session.EndTime = entity.EndTime;
            session.BookingOpenDate = entity.BookingOpenDate;
            session.BookingCloseDate = entity.BookingCloseDate;
            applicationContext.SaveChanges();
            return session;
        }

        public async Task<Session> DeleteSessionAsync(Guid id)
        {
            var session = await GetSessionAsync(id);
            applicationContext.Sessions.Remove(session);
            applicationContext.SaveChanges();
            return session;
        }
    }
}
