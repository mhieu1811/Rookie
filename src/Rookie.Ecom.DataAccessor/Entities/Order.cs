using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rookie.Ecom.DataAccessor.Entities
{
    public class Order:BaseEntity
    {
        public DateTime Time { get; set; }
        public Guid? UserID { get; set; }
        public int Total { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine { get; set; }
        public Status Status { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }
    }
    public enum Status
    {
        Done, Delivery, Cancel, Pending
    }
}
