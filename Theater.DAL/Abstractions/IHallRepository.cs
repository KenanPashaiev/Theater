using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.Models;

namespace Theater.DAL.Abstractions
{
    public interface IHallRepository
    {
        Task<Hall> GetHallAsync(Guid id);

        Task<Hall> GetHallByNameAsync(string name);

        Task<IEnumerable<Hall>> GetAllHallsAsync(bool includeInactive);

        Task<Hall> AddHallAsync(Hall entity);

        Task<Hall> UpdateHallAsync(string name, Hall entity);

        Task<Hall> DeleteHallAsync(string name);
    }
}
