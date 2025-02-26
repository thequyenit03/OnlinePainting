using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheQuyen.OnlinePainting.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Painting")]
        public int PaintingId { get; set; }
        public virtual Painting? Painting { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; }

        public string ShippingAddress { get; set; }

        public string OrderNote { get; set; }
    }

}
