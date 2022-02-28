using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Product : BaseEntity
    {

        [Required]
        [StringLength(maximumLength: 50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }

        public int Price { get; set; }

        public bool IsFeatured { get; set; }

        public int Quantity { get; set; }

        public bool Status { get; set; }

        public ICollection<ProductDetails> ProductDetails { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }

    }
}
