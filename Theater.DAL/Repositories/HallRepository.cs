using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.DAL.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly ApplicationContext applicationContext;

        public HallRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<Hall> GetHallAsync(Guid id)
        {
            return await applicationContext.Halls
                .Include(h => h.HallSections)
                .SingleOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hall> GetHallByNameAsync(string name)
        {
            var now = DateTime.UtcNow;
            return await applicationContext.Halls
                .Include(h => h.HallSections)
                .OrderByDescending(h => h.EffectiveTime)
                .FirstOrDefaultAsync(h => h.Name == name && h.EffectiveTime <= now);
        }

        public async Task<IEnumerable<Hall>> GetAllHallsAsync(bool includeInactive)
        {
            var now = DateTime.UtcNow;
            var halls = await applicationContext.Halls
                .Include(h => h.HallSections)
                .Where(h => h.EffectiveTime <= now)
                .OrderByDescending(h => h.EffectiveTime)
                .ToListAsync();

            var filteredHalls = halls;
            if(!includeInactive)
            {
                filteredHalls = halls.GroupBy(h => h.Name)
                    .Select(g => g.FirstOrDefault()).ToList();
            }

            filteredHalls.ForEach(h => h.HallSections.OrderBy(s => s.Order));
            return filteredHalls;
        }

        public async Task<Hall> GetByDateAsync(string hallName, DateTime date)
        {
            return await applicationContext.Halls
                .Include(h => h.HallSections)
                .Where(h => h.EffectiveTime <= date && h.Name == hallName)
                .OrderByDescending(h => h.EffectiveTime)
                .FirstOrDefaultAsync();
        }

        public async Task<Hall> AddHallAsync(Hall entity)
        {
            var hall = await applicationContext.Halls.AddAsync(entity);
            applicationContext.SaveChanges();
            return await GetHallAsync(hall.Entity.Id);
        }

        public async Task<Hall> UpdateHallAsync(string name, Hall entity)
        {
            var hall = (await applicationContext.Halls.AddAsync(entity)).Entity;
            applicationContext.SaveChanges();
            return hall;
        }

        public async Task<Hall> DeleteHallAsync(string name)
        {
            var halls = applicationContext.Halls.Where(h => h.Name == name);
            applicationContext.Halls.RemoveRange(halls);
            applicationContext.SaveChanges();
            return await halls.OrderByDescending(h => h.EffectiveTime).FirstOrDefaultAsync();
        }
    }
}
