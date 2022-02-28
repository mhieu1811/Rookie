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
    public class RatingService : IRatingService
    {
        private readonly IBaseRepository<Rating> _baseRepository;
        private readonly IMapper _mapper;

        public RatingService(IBaseRepository<Rating> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<RatingDto> AddAsync(RatingDto RatingDto)
        {
            var Rating = _mapper.Map<Rating>(RatingDto);
            var item = await _baseRepository.AddAsync(Rating);
            return _mapper.Map<RatingDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(RatingDto RatingDto)
        {
            var Rating = _mapper.Map<Rating>(RatingDto);
            await _baseRepository.UpdateAsync(Rating);
        }

        public async Task<IEnumerable<RatingDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<RatingDto>>(categories);
        }

        public async Task<RatingDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var Rating = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<RatingDto>(Rating);
        }

       /* public async Task<RatingDto> GetByNameAsync(string name)
        {
            var Rating = await _baseRepository.GetByAsync(x => x.RatingName == name);
            return _mapper.Map<RatingDto>(Rating);
        }

        public async Task<PagedResponseModel<RatingDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.RatingName.Contains(name));

            query = query.OrderBy(x => x.RatingName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<RatingDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems, 
                Items = _mapper.Map<IEnumerable<RatingDto>>(assets.Items)
            };
        }*/

    }
}
