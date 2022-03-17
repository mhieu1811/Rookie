using System;

namespace Rookie.Ecom.Contracts.Dtos
{
    public class ProductDetailsUpdateDto : BaseDto
    {
        public Guid? CategoryID { get; set; }
        public Guid? ProductID { get; set; }
        /*        public ProductDto Product { get; set; }
        */
    }
}
