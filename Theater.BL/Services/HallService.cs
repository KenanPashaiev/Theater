using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Theater.BL.Models.Hall;
using Theater.DAL.Abstractions;
using Theater.Models;

namespace Theater.BL.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository hallRepository;
        private readonly IMapper mapper;

        public HallService(IHallRepository hallRepository, IMapper mapper)
        {
            this.hallRepository = hallRepository;
            this.mapper = mapper;
        }

        public async Task<HallDto> GetHallAsync(Guid id)
        {
            var hall = await hallRepository.GetHallAsync(id);
            return mapper.Map<HallDto>(hall);
        }

        public async Task<HallDto> GetHallByNameAsync(string name)
        {
            var hall = await hallRepository.GetHallByNameAsync(name);
            return mapper.Map<HallDto>(hall);
        }

        public async Task<IEnumerable<HallDto>> GetAllHallsAsync(bool includeInactive)
        {
            var halls = await hallRepository.GetAllHallsAsync(includeInactive);
            return mapper.Map<IEnumerable<HallDto>>(halls);
        }

        public async Task<HallDto> AddHallAsync(HallCreateDto hallDtoToAdd)
        {
            var hallToAdd = mapper.Map<Hall>(hallDtoToAdd);
            var addedHall = await hallRepository.AddHallAsync(hallToAdd);
            return mapper.Map<HallDto>(addedHall);
        }

        public async Task<HallDto> UpdateHallAsync(string name, HallUpdateDto hallDtoPayload)
        {
            var hallPayload = mapper.Map<Hall>(hallDtoPayload);
            hallPayload.Name = name;
            var updatedHall = await hallRepository.UpdateHallAsync(name, hallPayload);
            return mapper.Map<HallDto>(updatedHall);
        }

        public async Task<HallDto> DeleteHallAsync(string name)
        {
            var hall = await hallRepository.DeleteHallAsync(name);
            return mapper.Map<HallDto>(hall);
        }
    }
}
