using Rookie.Ecom.Contracts;
using Rookie.Ecom.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rookie.Ecom.Business.Interfaces
{
    public interface IUserDetailsService
    {
        Task<IEnumerable<UserDetailsDto>> GetAllAsync();

/*        Task<PagedResponseModel<UserDetailsDto>> PagedQueryAsync(string name, int page, int limit);
*/
        Task<UserDetailsDto> GetByIdAsync(Guid id);

/*        Task<UserDetailsDto> GetByNameAsync(string name);
*/
        Task<UserDetailsDto> AddAsync(UserDetailsDto categoryDto);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(UserDetailsDto categoryDto);
    }
}
