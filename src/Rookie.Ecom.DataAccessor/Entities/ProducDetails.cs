using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class ProductDetails:BaseEntity
    {
        
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }

    }
}
