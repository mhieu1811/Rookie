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
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IBaseRepository<ProductDetails> _productdetails;
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> baseRepository, IBaseRepository<ProductDetails> productdetails, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _productdetails = productdetails;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddAsync(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            var item = await _baseRepository.AddAsync(Product);
            return _mapper.Map<ProductDto>(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(ProductDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            await _baseRepository.UpdateAsync(Product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var categories = await _baseRepository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(categories);
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var query = _baseRepository.Entities;

            // map roles and users: collection (roleid, userid)
            // upsert: delete, update, insert
            // input vs db
            // input-y vs db-no => insert
            // input-n vs db-yes => delete
            // input-y vs db-y => update
            // unique, distinct, no-duplicate
            var Product = await _baseRepository.GetByAsync(m=>m.Id==id, "ProductPictures,ProductDetails,ProductDetails.Category,Ratings");

            return _mapper.Map<ProductDto>(Product);
        }

        /*public async Task<ProductDto> GetByNameAsync(string name) c 
        {
            var Product = await _baseRepository.GetByAsync(x => x.ProductName == name);
            return _mapper.Map<ProductDto>(Product);
        }*/

        public async Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string? name, int page, int limit, string? categoryID)
        {
            var query = _baseRepository.Entities;
            query = query.Include(m => m.ProductPictures).Include(n=>n.ProductDetails);
            /*if (categoryID.Length != 0)
            {
                query = query.Include("ProductDetails").Include("Category");
                foreach (var cate in categoryID)
                {
                    query = query.Join(test.Entities, a => a.Id, b => b.ProductID, (a, b) => new { a, b }).Where(m => m.b.CategoryID.Equals(cate)).Select(n => n.a);
                }
            }*/
/*            query = from d in query
                    join lo in _productdetails.Entities on d.Id equals lo.ProductID
                    where string.IsNullOrEmpty(categoryID) || lo.CategoryID == Guid.Parse(categoryID)
                    select d;*/

            /*            Guid g = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
            */
            /*            var cate  = _productdetails.Entities.Where(m=> string.IsNullOrEmpty(categoryID)||m.CategoryID==Guid.Parse(categoryID));
            */
            query = query.Where(m => string.IsNullOrEmpty(categoryID) || m.ProductDetails.Any(n=>n.CategoryID== Guid.Parse(categoryID)));

            /*            query = query.Join(test.Entities, a => a.Id, b => b.ProductID, (a, b) => new { a, b }).Where(m => m.b.CategoryID.Equals(categoryID)).Select(n => n.a);
            */
            query = query.Where(x => x.IsFeatured == true);  
            query = query.Where(x =>  string.IsNullOrEmpty(name)|| x.ProductName.Contains(name));

            query = query.OrderBy(x => x.ProductName);

            var assets = await query
                .AsNoTracking()
                .PaginateAsync(page, limit);

            return new PagedResponseModel<ProductDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = _mapper.Map<IEnumerable<ProductDto>>(assets.Items)
            };
        }
    }
}
