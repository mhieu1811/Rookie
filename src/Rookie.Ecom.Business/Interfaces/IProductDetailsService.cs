using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IProductDetailsService
    {
        Task<IEnumerable<ProductDetailsDto>> GetAllAsync();

/*        Task<PagedResponseModel<ProductDetailsDto>> PagedQueryAsync(string name, int page, int limit);
*/
        Task<ProductDetailsDto> GetByIdAsync(Guid id);
        


        /*        Task<ProductDetailsDto> GetByNameAsync(string name);*/

        Task<ProductDetailsDto> AddAsync(ProductDetailsDto categoryDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(ProductDetailsDto categoryDto);
    }
}