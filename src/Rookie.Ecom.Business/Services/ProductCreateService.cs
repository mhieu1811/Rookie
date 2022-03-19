using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Services
{
    public class ProductCreateService : IProductCreateService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly IProductDetailsService _productdetails;
        private readonly IProductPictureService _productpicture;
        private readonly IStorageService _storageService;

        private readonly IMapper _mapper;

        public ProductCreateService(IBaseRepository<Product> baseRepository, IStorageService storageService, IProductPictureService productpicture, IProductDetailsService productdetails, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _productdetails = productdetails;
            _productpicture = productpicture;
            _storageService = storageService;
            _mapper = mapper;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
        public async Task<ProductCreateDto> AddAsync(ProductCreateDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            var item = await _baseRepository.AddAsync(Product);
            foreach(var pic in ProductDto.Picture)
            {
                ProductPictureDto propic = new ProductPictureDto();
                propic.ProductId = ProductDto.Id;
                propic.Pubished = true;
                propic.Id = Guid.NewGuid();
                propic.CreatedDate = DateTime.Now;
                propic.UpdatedDate = DateTime.Now;
                propic.Title = await SaveFile(pic);
                propic.PictureUrl = await SaveFile(pic);
                await _productpicture.AddAsync(propic);
            }
            foreach(var cate in ProductDto.Cate)
            {
                ProductDetailsDto prodetail = new ProductDetailsDto();
                prodetail.ProductID = ProductDto.Id;
                prodetail.CategoryID = Guid.Parse(cate);
                prodetail.Id= Guid.NewGuid();
                prodetail.Pubished = true;
                prodetail.CreatedDate = DateTime.Now;
                prodetail.UpdatedDate = DateTime.Now;
                await _productdetails.AddAsync(prodetail);
            }
            return _mapper.Map<ProductCreateDto>(item);
        }

        /*public async Task DeleteAsync(Guid id)
        {
            await _baseRepository.DeleteAsync(id);
        }*/

        public async Task UpdateAsync(ProductCreateDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            await _baseRepository.UpdateAsync(Product);
                var listdetail = await _productdetails.GetByIdProductAsync(ProductDto.Id);
            if (ProductDto.Picture != null)
            {
                var listpic = await _productpicture.GetByIdProductAsync(ProductDto.Id);
                foreach(var p in listpic)
                {
                    await _productpicture.DeleteAsync(p.Id);
                }
                foreach (var pic in ProductDto.Picture)
                {
                    ProductPictureDto propic = new ProductPictureDto();
                    propic.ProductId = ProductDto.Id;
                    propic.Pubished = true;
                    propic.Id = Guid.NewGuid();
                    propic.CreatedDate = DateTime.Now;
                    propic.UpdatedDate = DateTime.Now;
                    propic.Title = await SaveFile(pic);
                    propic.PictureUrl = await SaveFile(pic);
                    await _productpicture.AddAsync(propic);
                }
            }
            foreach (var d in listdetail)
            {
                await _productdetails.DeleteAsync(d.Id);
            }
            foreach (var cate in ProductDto.Cate)
            {
                ProductDetailsDto prodetail = new ProductDetailsDto();
                prodetail.ProductID = ProductDto.Id;
                prodetail.CategoryID = Guid.Parse(cate);
                prodetail.Id = Guid.NewGuid();
                prodetail.Pubished = true;
                prodetail.CreatedDate = DateTime.Now;
                prodetail.UpdatedDate = DateTime.Now;
                    await _productdetails.AddAsync(prodetail);
            }
        }

        /*public async Task<IEnumerable<ProductDto>> GetAllAsync()
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
            var Product = await _baseRepository.GetByAsync(m => m.Id == id, "ProductPictures,ProductDetails,ProductDetails.Category,Ratings");

            return _mapper.Map<ProductDto>(Product);
        }*/

        /*public async Task<ProductDto> GetByNameAsync(string name) c 
        {
            var Product = await _baseRepository.GetByAsync(x => x.ProductName == name);
            return _mapper.Map<ProductDto>(Product);
        }*//*

        public async Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string? name, int page, int limit, string? categoryID, bool isFeature)
        {
            var query = _baseRepository.Entities;
            query = query.Include(m => m.ProductPictures).Include(n=>n.ProductDetails);
            query = query.Where(m => string.IsNullOrEmpty(categoryID) || m.ProductDetails.Any(n=>n.CategoryID== Guid.Parse(categoryID)));
            query = query.Where(x => !isFeature || x.IsFeatured == true);  
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
        }*/
    }
}
