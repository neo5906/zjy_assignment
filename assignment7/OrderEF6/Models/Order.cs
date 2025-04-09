using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderEF6.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [StringLength(50)]
        public string OrderId { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer { get; set; }

        public virtual ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();

        [NotMapped]
        public decimal TotalAmount
        {
            get
            {
                if (Details == null) return 0;
                return Details.Sum(d => d.UnitPrice * d.Quantity);
            }
        }
    }
}
