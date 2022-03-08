using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string CategoryName { get; set; }
        public string? CategoryPicture { get; set; }

        public ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
