﻿using AutoMapper;
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
    public class AddressService : IAddressService
    {
        private readonly IBaseRepository<Address> _baseRepository;
        private readonly IMapper _mapper;

        public AddressService(IBaseRepository<Address> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<AddressDto> AddAsync(AddressDto AddressDto)
        {
            var Address = _mapper.Map<Address>(AddressDto);
            var item = await _baseRepository.AddAsync(Address);
            return _mapper.Map<AddressDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(AddressDto AddressDto)
        {
            var Address = _mapper.Map<Address>(AddressDto);
            await _baseRepository.UpdateAsync(Address);
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<AddressDto>>(categories);
        }

        public async Task<AddressDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var Address = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<AddressDto>(Address);
        }

        /*public async Task<AddressDto> GetByNameAsync(string name)
        {
            var Address = await _baseRepository.GetByAsync(x => x.AddressName == name);
            return _mapper.Map<AddressDto>(Address);
        }

        public async Task<PagedResponseModel<AddressDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.AddressName.Contains(name));

            query = query.OrderBy(x => x.AddressName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<AddressDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<AddressDto>>(assets.Items)
            };
        }*/

    }
}
