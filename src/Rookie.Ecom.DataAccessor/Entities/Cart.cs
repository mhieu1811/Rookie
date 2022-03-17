using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Cart:BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
