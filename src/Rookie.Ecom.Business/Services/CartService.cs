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
    public class CartService : ICartService
    {
        private readonly IBaseRepository<Cart> _baseRepository;
        private readonly IMapper _mapper;

        public CartService(IBaseRepository<Cart> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<CartDto> AddAsync(CartDto CartDto)
        {
            var Cart = _mapper.Map<Cart>(CartDto);
            var item = await _baseRepository.AddAsync(Cart);
            return _mapper.Map<CartDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(CartDto CartDto)
        {
            var Cart = _mapper.Map<Cart>(CartDto);
            await _baseRepository.UpdateAsync(Cart);
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<CartDto>>(categories);
        }

        public async Task<CartDto> GetByIdAsync(Guid id)
        {
            // map Carts and users: collection (Cartid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var Cart = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<CartDto>(Cart);
        }

        /*public async Task<CartDto> GetByNameAsync(string name)
        {
            var Cart = await _baseRepository.GetByAsync(x => x.CartName == name);
            return _mapper.Map<CartDto>(Cart);
        }

        public async Task<PagedResponseModel<CartDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.CartName.Contains(name));

            query = query.OrderBy(x => x.CartName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<CartDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<CartDto>>(assets.Items)
            };
        }*/

    }
}
