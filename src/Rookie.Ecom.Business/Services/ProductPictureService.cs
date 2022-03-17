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
    public class ProductPictureService : IProductPictureService
    {
        private readonly IBaseRepository<ProductPicture> _baseRepository;
        private readonly IMapper _mapper;

        public ProductPictureService(IBaseRepository<ProductPicture> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<ProductPictureDto> AddAsync(ProductPictureDto ProductPictureDto)
        {
            var ProductPicture = _mapper.Map<ProductPicture>(ProductPictureDto);
            var item = await _baseRepository.AddAsync(ProductPicture);
            return _mapper.Map<ProductPictureDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductPictureDto ProductPictureDto)
        {
            var ProductPicture = _mapper.Map<ProductPicture>(ProductPictureDto);
            await _baseRepository.UpdateAsync(ProductPicture);
        }

        public async Task<IEnumerable<ProductPictureDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductPictureDto>>(categories);
        }

        public async Task<List<ProductPictureDto>> GetByIdProductAsync(Guid id)
        {
            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var ProductPicture = _baseRepository.Entities.Where(m => m.ProductId == id).ToList();
            return _mapper.Map<List<ProductPictureDto>>(ProductPicture);
        }


       /* public async Task<ProductPictureDto> GetByNameAsync(string name)
        {
            var ProductPicture = await _baseRepository.GetByAsync(x => x.ProductPictureName == name);
            return _mapper.Map<ProductPictureDto>(ProductPicture);
        }

        public async Task<PagedResponseModel<ProductPictureDto>> PagedQueryAsync(string name, int page, int limit)
        {
            var query = _baseRepository.Entities;

            query = query.Where(x => string.IsNullOrEmpty(name) || x.ProductPictureName.Contains(name));

            query = query.OrderBy(x => x.ProductPictureName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductPictureDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductPictureDto>>(assets.Items)
            };
        }*/

    }
}
