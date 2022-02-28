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
    public class OrderItemService : IOrderItemService
    {
        private readonly IBaseRepository<OrderItem> _baseRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IBaseRepository<OrderItem> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemDto> AddAsync(OrderItemDto OrderItemDto)
        {
            var OrderItem = _mapper.Map<OrderItem>(OrderItemDto);
            var item = await _baseRepository.AddAsync(OrderItem);
            return _mapper.Map<OrderItemDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(OrderItemDto OrderItemDto)
        {
            var OrderItem = _mapper.Map<OrderItem>(OrderItemDto);
            await _baseRepository.UpdateAsync(OrderItem);
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<OrderItemDto>>(categories);
        }

        public async Task<OrderItemDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var OrderItem = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<OrderItemDto>(OrderItem);
        }

       /* public async Task<OrderItemDto> GetByNameAsync(string name)
        {
            var OrderItem = await _baseRepository.GetByAsync(x => x.OrderItemName == name);
            return _mapper.Map<OrderItemDto>(OrderItem);
        }

        public async Task<PagedResponseModel<OrderItemDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.OrderItemName.Contains(name));

            query = query.OrderBy(x => x.OrderItemName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<OrderItemDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<OrderItemDto>>(assets.Items)
            };
        }*/

    }
}
