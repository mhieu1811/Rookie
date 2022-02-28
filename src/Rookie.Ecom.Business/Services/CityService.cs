using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class CityService : ICityService
    {
        private readonly IBaseRepository<City> _baseRepository;
        private readonly IMapper _mapper;

        public CityService(IBaseRepository<City> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CityDto> AddAsync(CityDto CityDto)
        {
            var City = _mapper.Map<City>(CityDto);
            var item = await _baseRepository.AddAsync(City);
            return _mapper.Map<CityDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(CityDto CityDto)
        {
            var City = _mapper.Map<City>(CityDto);
            await _baseRepository.UpdateAsync(City);
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<CityDto>>(categories);
        }

        public async Task<CityDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var City = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<CityDto>(City);
        }

        public async Task<CityDto> GetByNameAsync(string name)
        {
            var City = await _baseRepository.GetByAsync(x => x.CityName == name);
            return _mapper.Map<CityDto>(City);
        }

        public async Task<PagedResponseModel<CityDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.CityName.Contains(name));

            query = query.OrderBy(x => x.CityName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<CityDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<CityDto>>(assets.Items)
            };
        }

    }
}
