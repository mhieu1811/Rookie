using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string CategoryName { get; set; }
        public string CategoryPicture { get; set; }
        public IFormFile? Picture { get; set; }
        public ICollection<ProductDetailsUpdateDto> ProductDetails { get; set; }
    }
}
