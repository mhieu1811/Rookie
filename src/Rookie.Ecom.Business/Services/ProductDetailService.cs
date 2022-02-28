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
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IBaseRepository<ProductDetails> _baseRepository;
        private readonly IMapper _mapper;

        public ProductDetailsService(IBaseRepository<ProductDetails> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductDetailsDto> AddAsync(ProductDetailsDto ProductDetailsDto)
        {
            var ProductDetails = _mapper.Map<ProductDetails>(ProductDetailsDto);
            var item = await _baseRepository.AddAsync(ProductDetails);
            return _mapper.Map<ProductDetailsDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductDetailsDto ProductDetailsDto)
        {
            var ProductDetails = _mapper.Map<ProductDetails>(ProductDetailsDto);
            await _baseRepository.UpdateAsync(ProductDetails);
        }

        public async Task<IEnumerable<ProductDetailsDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductDetailsDto>>(categories);
        }

        public async Task<ProductDetailsDto> GetByIdAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var ProductDetails = await _baseRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDetailsDto>(ProductDetails);
        }

        /*public async Task<ProductDetailsDto> GetByNameAsync(string name)
        {
            var ProductDetails = await _baseRepository.GetByAsync(x => x.ProductDetailsName == name);
            return _mapper.Map<ProductDetailsDto>(ProductDetails);
        }

        public async Task<PagedResponseModel<ProductDetailsDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.ProductDetailsName.Contains(name));

            query = query.OrderBy(x => x.ProductDetailsName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductDetailsDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductDetailsDto>>(assets.Items)
            };
        }*/

    }
}
