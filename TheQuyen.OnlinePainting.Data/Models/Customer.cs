using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TheQuyen.OnlinePainting.Data.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
