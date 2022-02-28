using System;
using System.Collections.Generic;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductDto : BaseDto
    {

        public string ProductName { get; set; }
        public string Desc { get; set; }

        public int Price { get; set; }

        public bool IsFeatured { get; set; }

        public int Quantity { get; set; }

        public bool Status { get; set; }

        public ICollection<ProductDetailsDto> ProductDetails { get; set; }
/*        public ICollection<OrderItemDto> OrderItems { get; set; }
*/        public ICollection<ProductPictureDto> ProductPictures { get; set; }

    }

}
