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
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IBaseRepository<UserDetails> _baseRepository;
        private readonly IMapper _mapper;

        public UserDetailsService(IBaseRepository<UserDetails> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> AddAsync(UserDetailsDto UserDetailsDto)
        {
            var UserDetails = _mapper.Map<UserDetails>(UserDetailsDto);
            var item = await _baseRepository.AddAsync(UserDetails);
            return _mapper.Map<UserDetailsDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(UserDetailsDto UserDetailsDto)
        {
            var UserDetails = _mapper.Map<UserDetails>(UserDetailsDto);
            await _baseRepository.UpdateAsync(UserDetails);
        }

        public async Task<IEnumerable<UserDetailsDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<UserDetailsDto>>(categories);
        }

        public async Task<UserDetailsDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var UserDetails = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<UserDetailsDto>(UserDetails);
        }

       /* public async Task<UserDetailsDto> GetByNameAsync(string name)
        {
            var UserDetails = await _baseRepository.GetByAsync(x => x.UserDetailsName == name);
            return _mapper.Map<UserDetailsDto>(UserDetails);
        }

        public async Task<PagedResponseModel<UserDetailsDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.UserDetailsName.Contains(name));

            query = query.OrderBy(x => x.UserDetailsName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<UserDetailsDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<UserDetailsDto>>(assets.Items)
            };
        }*/

    }
}
