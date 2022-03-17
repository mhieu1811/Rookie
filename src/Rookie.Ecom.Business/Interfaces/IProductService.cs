﻿using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductService
    {

        Task<IEnumerable<ProductDto>> GetAllAsync();

/*        Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string name, int page, int limit);
*/
        Task<ProductDto> GetByIdAsync(Guid id);

        /*        Task<ProductDto> GetByNameAsync(string name);
        */
        Task<ProductDto> AddAsync(ProductDto categoryDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductDto categoryDto);
        Task<PagedResponseModel<ProductDto>> PagedQueryAsync(string? name, int page, int limit, string? categoryID, bool isFeature);
    }
}